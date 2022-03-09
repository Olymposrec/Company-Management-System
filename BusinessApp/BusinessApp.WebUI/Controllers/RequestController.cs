using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessApp.Business.Abstract;
using BusinessApp.Entity;
using BusinessApp.WebUI.Extensions;
using BusinessApp.WebUI.HangfireWorks.Schedules;
using BusinessApp.WebUI.Identity;
using BusinessApp.WebUI.Models;
using BusinessApp.WebUI.Models.RequestsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Controllers
{
    public class RequestController : Controller
    {
        private readonly INotyfService _notyf;

        private readonly ILogger<RequestController> _logger;

        private IServiceService _serviceService;
        private ICompaniesServicesService _servicesCompanyService;
        private IRequestService _requestService;
        private ICompanyService _companyService;
        private IFileUploadService _fileUploadService;
        private IRequestResponseService _requestResponseService;
        private IDepartmentService _departmentService;
        private IRequestDepartmentService _requestDepartmentService;
        private UserManager<User> _userManager;
        public RequestController(IServiceService serviceService
            , UserManager<User> userManager
            , ICompaniesServicesService servicesCompanyService
            , IRequestService requestService
            , IFileUploadService fileUploadService
            , IRequestResponseService requestResponseService
            , ICompanyService companyService
            , IDepartmentService departmentService
            , IRequestDepartmentService requestDepartmentService
            , INotyfService notyf
            , ILogger<RequestController> logger
            )
        {
            _serviceService = serviceService;
            _userManager = userManager;
            _servicesCompanyService = servicesCompanyService;
            _requestService = requestService;
            _fileUploadService = fileUploadService;
            _requestResponseService = requestResponseService;
            _companyService = companyService;
            _departmentService = departmentService;
            _requestDepartmentService = requestDepartmentService;

            _notyf = notyf;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> RequestCreate()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var services = _serviceService.GetAll();
            var companyService = _servicesCompanyService.GetAll();
            if (companyService == null)
            {
                _notyf.Warning("This field is unavailable.");
                return Redirect("/Home/Index");
            }

            return View(new RequestsModel()
            {
                Services = services,
                User = user,
                Requests = _requestService.GetAll(),
                CompaniesServices = companyService
            });
        }
        [HttpGet]
        public JsonResult RequestWaitingCount()
        {
            var requestCount = _requestService.GetAll().Where(c => c.RequestStatus == Entity.Request.EnumRequestStatus.Waiting).Count();
            return new JsonResult(requestCount);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> RequestCreate(RequestsModel model)
        {
            var serviceId = Request.Form["serviceId"].ToString();
            if (string.IsNullOrEmpty(serviceId))
            {
                _notyf.Warning("Dont leave fields the blank.");
                return RedirectToAction("RequestCreate");
            }
            var user = await _userManager.FindByIdAsync(model.User.Id);
            if (ModelState.IsValid)
            {              
                var company = _companyService.GetById((int)user.CompanyId);
                var departmentId = _departmentService.GetAll().Where(c => c.isDefault==true).Select(c => c.Id).FirstOrDefault();
                var companyServicesId = _servicesCompanyService.GetByCompanyAndServiceId(company.Id, Convert.ToInt32(serviceId));
                var entity = new Request()
                {
                    Description = model.Description,
                    CompaniesServiceId = companyServicesId.Id,
                    Title = model.Title,
                    RequestDate = DateTime.Now,
                    RequestStatus = Entity.Request.EnumRequestStatus.Waiting,
                    DepartmentId = departmentId,
                    UserId = model.User.Id
                };               

                if (model.Files != null)
                {
                    var files = new List<FileUpload>();
                    foreach (var file in model.Files)
                    {
                        var extention = Path.GetExtension(file.FileName);
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", randomName);
                        var newFiles = new FileUpload()
                        {
                            FileName = randomName,
                            FileExtension = extention,
                            FilePath = path
                        };


                        if (_fileUploadService.Validation(newFiles))
                        {
                            files.Add(newFiles);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                        else
                        {
                            _notyf.Warning("You cannot upload dll and exe files.");
                            return RedirectToAction("RequestCreate");
                        }
                    }
                    try
                    {
                        await _requestService.CreateAsync(entity);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    var requestDepartment = new RequestDepartment()
                    {
                        DepartmentId = (int)departmentId,
                        AddedDate = DateTime.Now,
                        RequestId = entity.Id
                    };
                    _requestDepartmentService.Create(requestDepartment);


                    foreach (var file in files)
                    {
                        file.RequestId = entity.Id;
                        _fileUploadService.Create(file);
                    }
                }
                else
                {                   
                    try
                    {
                        await _requestService.CreateAsync(entity);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    var requestDepartment = new RequestDepartment()
                    {
                        DepartmentId = (int)departmentId,
                        AddedDate = DateTime.Now,
                        RequestId = entity.Id
                    };
                    DelayedJobs.SendMailToDepartmentEmployeeForUnAnsweredRequests(requestDepartment.RequestId);
                    _requestDepartmentService.Create(requestDepartment);
                }

                _notyf.Success("Request Sent Successfully.");
                return RedirectToAction("RequestHistory");
            }
           

            ModelState.AddModelError("", "Model State Is Not Valid.");
            _notyf.Warning("Model State Is Not Valid.");
            return View(new RequestsModel()
            {
                Services = _serviceService.GetAll(),
                User = user,
                CompaniesServices = _servicesCompanyService.GetByFirmId((int)user.CompanyId)
        });
        }

        [HttpGet]
        public async Task<IActionResult> RequestHistory()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var companyServices = _servicesCompanyService.GetByFirmId((int)user.CompanyId);
            return View(new RequestsListModel()
            {
                Requests = _requestService.GetAll(),
                Services = _serviceService.GetAll(),
                CompaniesServices = companyServices.ToList(),
                Users = _userManager.Users.ToList(),
                User = user
            });
        }


        [HttpGet]
        public IActionResult ServiceRequestDetail(int? id)
        {
            if (id != null)
            {
                _notyf.Warning("Something Went Wrong.");
                return RedirectToAction("RequestHistory");
            }
            var serviceRequest = _requestService.GetById((int)id);
            var files = _fileUploadService.GetAll();
            var iFormFiles = new List<IFormFile>();

            foreach (var file in files)
            {
                iFormFiles.Add((IFormFile)file);
            }
          
            return View(new RequestsModel()
            {
                Request = serviceRequest,
                Services = _serviceService.GetAll(),
                CompaniesServices = _servicesCompanyService.GetAll(),
                Departments = _departmentService.GetAll(),
                EnumRequestStatus = serviceRequest.RequestStatus

            });
        }
        [HttpGet]
        public async Task<IActionResult> RequestDetail(int? id)
        {
            if (id == null)
            {
                _notyf.Warning("Something Went Wrong.");
                return RedirectToAction("RequestHistory");
            }
            var request = _requestService.GetById((int)id);
            if (request == null)
            {
                _notyf.Warning("Something Went Wrong.");
                return RedirectToAction("RequestHistory");
            }

            var files = _fileUploadService.GetAll();
            var user = await _userManager.FindByIdAsync(request.UserId);
            var departments = _departmentService.GetAll().ToList();
            var requestResponses = _requestResponseService.GetAll().Where(c => c.RequestId == id).OrderBy(c => c.ResponseDate).ToList();


            return View(new RequestsModel()
            {
                EnumRequestStatus = request.RequestStatus,
                Request = request,
                Departments = departments,
                Requests = _requestService.GetAll(),
                RequestDepartments = _requestDepartmentService.GetAll(),
                FilesDownload = files,
                Services = _serviceService.GetAll(),
                CompaniesServices = _servicesCompanyService.GetAll(),
                RequestResponses = requestResponses,
                User = user
            });
        }
        [HttpPost]
        public async Task<IActionResult> RequestDetail(RequestsModel response, int? requestId, string sendResponse)
        {
            if (string.IsNullOrEmpty(response.RequestResponse.Response))
            {
                _notyf.Warning("You cant send empty message.");
                return RedirectToAction("RequestDetail");
            }
            if (!string.IsNullOrEmpty(sendResponse))
            {
                var result = response.Request = _requestService.GetById((int)requestId);
                var entity = new RequestResponse()
                {
                    ResponseDate = DateTime.Now,
                    Response = response.RequestResponse.Response,
                    ResponseType = RequestResponse.EnumResponseType.Sender,
                    RequestId = (int)requestId
                };
                if (string.IsNullOrEmpty(response.RequestResponse.Response))
                {
                    _notyf.Warning("Response not null.");
                    return RedirectToAction("RequestDetail");
                }
                if (_requestResponseService.Create(entity))
                {
                    _notyf.Success("You Added a new response.");
                    return RedirectToAction("RequestDetail");
                }
                _notyf.Success("Request successfuly reopened.");
                return RedirectToAction("RequestDetail");
            }
            if (requestId == null)
            {
                _notyf.Error("Request Not Found.");
                return RedirectToAction("RequestDetail");
            }
            if (response == null)
            {
                _notyf.Error("Response Not Found.");
                return RedirectToAction("RequestDetail");
            }

            _notyf.Error("Something went wrong");
            return RedirectToAction("RequestDetail");

        }
    }
}
