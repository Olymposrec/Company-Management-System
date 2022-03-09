using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessApp.WebUI.HangfireWorks.Schedules;
using BusinessApp.Business.Abstract;
using BusinessApp.Entity;
using BusinessApp.WebUI.EmailServices;
using BusinessApp.WebUI.Extensions;
using BusinessApp.WebUI.Identity;
using BusinessApp.WebUI.Models;
using BusinessApp.WebUI.Models.CompanyModels;
using BusinessApp.WebUI.Models.RequestsModels;
using BusinessApp.WebUI.Models.ServiceModels;
using BusinessApp.WebUI.Models.UsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BusinessApp.WebUI.Models.LogsViewModels;

namespace BusinessApp.WebUI.Controllers
{
    [Authorize(Roles = "Admin ,Employee")]

    public class AdminController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<AdminController> _logger;

        #region ServiceInterfaces
        private ICompanyService _companyService;
        private IServiceService _serviceService;
        private IServiceUserService _serviceUserService;
        private IDepartmentService _departmentService;
        private IUsersApplicaitonService _usersApplications;
        private IFileUploadService _fileUploadService;
        private ICompaniesServicesService _companiesServicesService;
        private IRequestService _requestService;
        private IRequestResponseService _requestResponseService;
        private IEmployeeDepartmentService _employeeDepartmentService;
        private IRequestDepartmentService _requestDepartmentService;
        private IEmployeeRequestsService _employeeRequestsService;
        private ILogsService _logsService;

        //Mail
        private IEmailSender _emailSender;
        #endregion

        #region UserAndRoleManagers
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        #endregion
        //Dependency Injection
        public AdminController(
              ICompanyService companyService
            , IServiceService serviceService
            , IUsersApplicaitonService usersApplications
            , IEmailSender emailSender
            , IServiceUserService serviceUserService
            , ICompaniesServicesService servicesCompanyService
            , IRequestService requestService
            , IFileUploadService fileUploadService
            , IRequestResponseService serviceResponseService
            , IDepartmentService departmentService
            , IEmployeeDepartmentService employeeDepartmentService
            , IRequestDepartmentService requestDepartmentService
            , IEmployeeRequestsService employeeRequestsService
            , ILogsService logsService
            , UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager
            , INotyfService notyf
            , ILogger<AdminController> logger
            )
        {
            _companyService = companyService;
            _serviceService = serviceService;
            _roleManager = roleManager;
            _userManager = userManager;
            _usersApplications = usersApplications;
            _emailSender = emailSender;
            _fileUploadService = fileUploadService;
            _serviceUserService = serviceUserService;
            _companiesServicesService = servicesCompanyService;
            _requestService = requestService;
            _requestResponseService = serviceResponseService;
            _requestDepartmentService = requestDepartmentService;
            _departmentService = departmentService;
            _employeeDepartmentService = employeeDepartmentService;
            _employeeRequestsService = employeeRequestsService;
            _notyf = notyf;
            _logger = logger;
            _logsService = logsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompanyCreate()
        {
            return View(new CompanyModel()
            {
                Companies = _companyService.GetAll()
            });
        }
        [HttpPost]
        public IActionResult CompanyCreate(CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                var entity = new Entity.Company()
                {
                    Name = company.Name,
                    TaxNumber = company.TaxNumber,
                    PhoneNumber = company.PhoneNumber,
                    Email = company.Email
                };
                try
                {
                    if (_companyService.Create(entity))
                    {
                        _notyf.Success("You Added a new Company.");
                        return RedirectToAction("CompanyCreate");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e.Message);
                }
                finally
                {
                    _logger.LogWarning("finally");
                }


                _notyf.Error(_companyService.ErrorMessage);
            }
            return RedirectToAction("CompanyCreate");
        }
        [HttpGet]
        public IActionResult CompanyList()
        {
            return View(new CompanyModel()
            {
                Companies = _companyService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CompanyEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _companyService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var users = _userManager.Users.Where(s => s.CompanyId == id).ToList();
            var model = new CompanyModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                TaxNumber = entity.TaxNumber,
                Users = users
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CompanyEdit(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _companyService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.TaxNumber = model.TaxNumber;
                entity.Email = model.Email;

                _companyService.Update(entity);

                _notyf.Success("The Company has been successfully updated.");

                return RedirectToAction("CompanyCreate");
            }

            _notyf.Success(_companyService.ErrorMessage);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserDeleteFromCompany(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            result.CompanyId = null;
            await _userManager.UpdateAsync(result);

            _notyf.Error("The User has been deleted from Company. Please dont forget assocate user with a Company.");

            return RedirectToAction("CompanyCreate");

        }

        [HttpPost]
        public async Task<IActionResult> CompanyDelete(CompanyModel model)
        {
            var entity = _companyService.GetById(model.Id);
            if (entity != null)
            {
                var users = await _userManager.Users.ToListAsync();
                foreach (var user in users)
                {
                    user.EmailConfirmed = false;
                    entity.isDeleted = true;
                    if (entity.Id == user.CompanyId)
                    {
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            _companyService.Update(entity);
                        }
                    }
                }

            }
            _notyf.Success($"Company {model.Name}  has been deleted.");

            return RedirectToAction("CompanyCreate");
        }

        [HttpGet]
        public async Task<IActionResult> DefineEmployeeToDepartment()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var users = await _userManager.Users.ToListAsync();
            var usersInRoleEmployee = await _userManager.GetUsersInRoleAsync("Employee");
            return View(new AdminCompanyEmployeeList()
            {
                Companies = _companyService.GetAll(),
                Users = usersInRoleEmployee.ToList(),
                User = currentUser,
                Services = _serviceService.GetAll(),
                Departments = _departmentService.GetAll(),
                EmployeeDepartments = _employeeDepartmentService.GetAll()

            });
        }
        [HttpPost]
        public IActionResult DepartmentDelete(int departmentId)
        {
            var entity = _departmentService.GetById(departmentId);
            if (departmentId != 0)
            {
                entity = new Department()
                {
                    isDeleted = true
                };
                if (_departmentService.Update(entity))
                {
                    _notyf.Error("You delete a Department.");

                    return RedirectToAction("DepartmentCreate");
                }

                _notyf.Error(_departmentService.ErrorMessage);
                return RedirectToAction("DepartmentCreate");
            }

            _notyf.Information("Department Not Found");
            return RedirectToAction("DepartmentCreate");
        }
        [HttpPost]
        public async Task<IActionResult> DefineEmployeeToDepartment(int departmentId, string userId)
        {
            var selectedDepartment = Request.Form["departmentId"].ToString();
            if (string.IsNullOrEmpty(selectedDepartment))
            {
                _notyf.Warning("Please Select a Department.");
                return RedirectToAction("DefineEmployeeToDepartment");
            }
            var employee = await _userManager.FindByIdAsync(userId);
            var currentUser = await _userManager.GetUserAsync(User);
            if (employee != null)
            {

                var employeDepartment = new EmployeeDepartment()
                {
                    DepartmentId = departmentId,
                    EmployeeId = userId
                };
                if (!_employeeDepartmentService.FindByDepartmentAndEmployeeId(departmentId, userId))
                {
                    _employeeDepartmentService.Create(employeDepartment);

                    _notyf.Success($"Employee {employee.FirstName} Define To Department");
                    return RedirectToAction("DefineEmployeeToDepartment");
                }
                _notyf.Information("Employee Already In Department");
                return RedirectToAction("DefineEmployeeToDepartment");
            }

            _notyf.Warning("There is no data.");

            var model = new AdminCompanyEmployeeList()
            {
                Companies = _companyService.GetAll(),
                Users = _userManager.Users.ToList(),
                User = currentUser,
                Departments = _departmentService.GetAll()
            };
            return RedirectToAction("DefineEmployeeToDepartment", model);
        }

        [HttpPost]
        public IActionResult DeleteEmployeeFromDepartment(string userId, int departmentId)
        {
            var employeeDepartment = _employeeDepartmentService.GetAll().Where(c => c.EmployeeId == userId && c.DepartmentId == departmentId).FirstOrDefault();
            _employeeDepartmentService.Delete(employeeDepartment);
            _notyf.Success("Employee successfuly deleted from department.");
            return RedirectToAction("DefineEmployeeToDepartment");
        }
        [HttpGet]
        public IActionResult ServiceCreate()
        {
            return View(new ServiceModel() { Services = _serviceService.GetAll(), Departments = _departmentService.GetAll() });
        }

        [HttpPost]
        public IActionResult ServiceCreate(ServiceModel service)
        {
            var defaultDepartment = _departmentService.GetAll().Where(c => c.isDefault).FirstOrDefault();
            var selectedDepartment = Request.Form["departmentId"].ToString();
            if (defaultDepartment == null)
            {
                _notyf.Information("Please Define Default Department.");
                return RedirectToAction("ServiceCreate");
            }
            if (ModelState.IsValid)
            {
                var entity = new Service()
                {
                    ServiceName = service.ServiceName,
                    ServiceDescription = service.ServiceDescription,
                    DepartmentId = defaultDepartment.Id
                };
                if (!string.IsNullOrEmpty(selectedDepartment))
                {
                    entity.DepartmentId = Convert.ToInt32(selectedDepartment);
                }


                if (_serviceService.Create(entity))
                {
                    _notyf.Success("You Added a new service.");

                    return RedirectToAction("ServiceCreate");
                }
            }
            _notyf.Error(_serviceService.ErrorMessage);

            return RedirectToAction("ServiceCreate");
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            return View(new ServiceModel()
            {
                Services = _serviceService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult ServiceEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _serviceService.GetByIdWithUsers((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ServiceModel()
            {
                Id = entity.Id,
                ServiceName = entity.ServiceName,
                DepartmentId = (int)entity.DepartmentId,
                ServiceDescription = entity.ServiceDescription,
                Services = _serviceService.GetAll(),
                Departments = _departmentService.GetAll()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ServiceEdit(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _serviceService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }
                entity.ServiceDescription = model.ServiceDescription;
                entity.ServiceName = model.ServiceName;
                entity.DepartmentId = model.DepartmentId;

                _serviceService.Update(entity);

                _notyf.Success("The Service has been successfully updated.");
                return RedirectToAction("ServiceCreate");
            }

            _notyf.Error(_serviceService.ErrorMessage);
            return View(model);
        }
        [HttpPost]
        public IActionResult ServiceDelete(ServiceModel model)
        {
            var entity = _serviceService.GetById(model.Id);
            entity.isDeleted = true;
            if (entity != null)
            {
                _serviceService.Update(entity);
            }
            _notyf.Success($"Service {model.ServiceName} has been deleted.");
            return RedirectToAction("ServiceCreate");
        }
        [HttpGet]
        public IActionResult UserCreate()
        {
            var roles = _roleManager.Roles.Select(i => new IdentityRole() { Id = i.Id, Name = i.Name }).ToList();
            var companies = _companyService.GetAll().Where(c => c.isDeleted != true).Select(p => new Company() { Id = p.Id, Name = p.Name }).ToList();
            var package = new UserModel()
            {
                Companies = companies,
                Roles = roles
            };
            return View(package);
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel model, string selectedRole)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isDefaultDepartment = _departmentService.GetAll().Any(c => c.isDefault == true && c.isDeleted == false);

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                CompanyId = model.SelectedCompany
            };
            if (selectedRole == "Customer")
            {
                try
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        selectedRole = selectedRole ?? "Customer";
                        if (!await _roleManager.RoleExistsAsync(selectedRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole());
                        }
                        await _userManager.AddToRoleAsync(user, selectedRole);
                        _notyf.Success("You Added a new user.");
                        return RedirectToAction("UserList");
                    }
                    ModelState.AddModelError("", $"{result.Errors.FirstOrDefault().Description.ToString()}");


                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"{e.Message.ToString()}");
                }
            }
            if (selectedRole == "Employee")
            {
                if (isDefaultDepartment == false)
                {
                    _notyf.Information("If You Want To add a new Employee, First define default department.");
                    return RedirectToAction("UserList");
                }
                int? defaultDepartmentId = _departmentService.GetAll().Where(c => c.isDefault == true).FirstOrDefault().Id;
                try
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        selectedRole = selectedRole ?? "Customer";
                        if (!await _roleManager.RoleExistsAsync(selectedRole))
                        {
                            await _roleManager.CreateAsync(new IdentityRole());
                        }
                        await _userManager.AddToRoleAsync(user, selectedRole);
                        var newEmployee = new EmployeeDepartment()
                        {
                            DepartmentId = defaultDepartmentId,
                            EmployeeId = user.Id
                        };
                        _employeeDepartmentService.Create(newEmployee);
                        _notyf.Success("You Added a new Employee.");
                        return RedirectToAction("UserList");
                    }
                    ModelState.AddModelError("", $"{result.Errors.FirstOrDefault().Description.ToString()}");


                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"{e.Message.ToString()}");
                }
            }

            model.Companies = _companyService.GetAll().Select(p => new Company() { Id = p.Id, Name = p.Name }).ToList();
            model.Roles = _roleManager.Roles.Select(i => new IdentityRole() { Id = i.Id, Name = i.Name }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {

                var companies = _companyService.GetAll();
                var roles = _roleManager.Roles.Select(i => new IdentityRole() { Id = i.Id, Name = i.Name }).ToList();
                var selectedRole = "Customer";
                foreach (var role in roles)
                {
                    var usersInRole = await _userManager.IsInRoleAsync(user, role.Name);
                    if (usersInRole)
                    {
                        selectedRole = role.Name;
                        break;
                    }
                }
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    CompanyId = user.CompanyId,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    Role = selectedRole.ToString(),
                    Companies = companies,
                    Roles = roles
                });
            }
            return Redirect("~/Admin/Users");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model, string selectedRole)
        {
            if (ModelState.IsValid)
            {
                var entity = await _userManager.FindByIdAsync(model.UserId);
                var companyId = Request.Form["companyId"];

                if (entity == null)
                {
                    _notyf.Warning("Data Not Found.");
                }
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.CompanyId = Convert.ToInt32(companyId);

                var result = await _userManager.UpdateAsync(entity);

                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(entity);
                    selectedRole = selectedRole ?? "";
                    model.Role = selectedRole;
                    var user = await _userManager.FindByIdAsync(model.UserId);
                    await _userManager.RemoveFromRolesAsync(user, roles);
                    await _userManager.AddToRoleAsync(user, selectedRole);
                }
                _notyf.Success("The User has been successfully updated.");

                return RedirectToAction("UserList");
            }
            _notyf.Error("Model State is not valid.");
            model.Roles = _roleManager.Roles.Select(i => new IdentityRole() { Id = i.Id, Name = i.Name }).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserDelete(UserModel model)
        {
            var entity = _userManager.Users.Where(c => c.Id == model.Id).FirstOrDefault();
            if (entity != null)
            {
                entity.isPassive = true;
                await _userManager.UpdateAsync(entity);
            }
            _notyf.Success($"User {model.FirstName + ' ' + model.LastName}  has been deleted  ");
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult UserRoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRoleCreate(UserRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var isThereRole = await _roleManager.RoleExistsAsync(model.RoleName);
                if (isThereRole)
                {
                    _notyf.Information($"{model.RoleName} role already exists. ");
                    return RedirectToAction("UserRoleCreate");
                }
                var result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
                if (result.Succeeded)
                {
                    _notyf.Success("You Added a new user role.");
                    return RedirectToAction("UserRoleList");
                }
                else
                {
                    _notyf.Error("Role Manager Not Succeeded.");
                }
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public IActionResult UserRoleList()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> UserRoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonmembers = new List<User>();
            var UserList = _userManager.Users.ToList();
            foreach (var user in UserList)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserRoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect("/Admin/Role/" + model.RoleId);
        }
        [HttpPost]
        public async Task<IActionResult> UserRoleDelete(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);
            if (entity != null)
            {
                await _roleManager.DeleteAsync(entity);
            }
            _notyf.Success($"User Role {entity.Name} has been deleted.");
            return RedirectToAction("UserRoleList");
        }
        [HttpGet]
        public IActionResult ApplicationsList()
        {
            return View(new UsersApplicationListModel()
            {
                Companies = _companyService.GetAll(),
                Users = _userManager.Users.ToList(),
                UsersApplications = _usersApplications.GetAll()

            });
        }
        [HttpGet]
        public IActionResult ApplicationsEdit(string UserId)
        {
            if (UserId == null)
            {
                return NotFound();
            }
            var entity = _usersApplications.GetByStringId(UserId);
            if (entity == null)
            {
                return NotFound();
            }
            var users = _userManager.Users.Where(s => s.Id == UserId).ToList();
            var firms = _companyService.GetAll();
            var model = new UsersApplicationModel()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                CompanyName = entity.CompanyName,
                Users = users,
                Companies = firms
            };
            firms.Select(p => new Company()
            {
                Id = p.Id,
                Name = p.Name
            });
            ViewBag.Firms = firms;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ApplicationsEdit(UsersApplicationModel model)
        {
            var entity = await _userManager.FindByIdAsync(model.UserId);
            var companyId = Request.Form["companyId"].ToString();
            if (string.IsNullOrEmpty(companyId))
            {
                _notyf.Warning("Please dont leave fields blank.");
                return RedirectToAction("ApplicationsList");
            }
            if (entity == null)
            {
                _notyf.Warning("The user not found.");
                return RedirectToAction("ApplicationsList");
            }

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.CompanyId = Convert.ToInt32(companyId);
            entity.isPassive = true;
            await _userManager.UpdateAsync(entity);

            var app = _usersApplications.GetAll().Where(c => c.UserId == entity.Id).FirstOrDefault();
            app.Id = model.Id;
            app.UserId = model.UserId;
            app.FirstName = model.FirstName;
            app.LastName = model.LastName;
            app.UserName = model.UserName;
            app.CompanyName = model.CompanyName;
            app.Email = model.Email;
            app.PhoneNumber = model.PhoneNumber;

            _usersApplications.Update(app);


            _notyf.Success("The user application has been successfully updated.");
            return RedirectToAction("ApplicationsList");
        }
        [HttpPost]
        public async Task<IActionResult> ApplicationConfirm(string userId)
        {
            var entity = _usersApplications.GetByStringId(userId);
            var company = _companyService.GetIdWithName(entity.CompanyName);
            var currentUser = await _userManager.FindByIdAsync(userId);
            if (entity != null)
            {
                if (!company.Equals(0))
                {
                    currentUser.CompanyId = company;
                    currentUser.EmailConfirmed = true;
                    await _userManager.UpdateAsync(currentUser);
                    // send mail to user for can use web site info
                    await _emailSender.SendEmailAsync(
                            currentUser.Email,
                            "CompanyApp - Your account has been approved."
                            , $"<div class='row'><div class='col-sm-4'></div><div class='col-sm-4'><h3>Company App</h3><hr><h5>Your Account is Approved</h5><hr><p>You can click this <a href='https://localhost:44342/Account/Login'>link</a> to login to your account.</p></div><div class='col-sm-4'></div></ div > "
                        );
                    entity.ApplicationStatus = UsersApplication.EnumApplicationStatus.Accepted;
                    _usersApplications.Update(entity);
                }
                else
                {
                    _notyf.Warning($"{entity.CompanyName} company is not found. Please add first new company");
                    return RedirectToAction("ApplicationsList");
                }

            }

            _notyf.Success($"The User is associated with the {entity.CompanyName} company.");
            return RedirectToAction("ApplicationsList");
        }
        [HttpPost]
        public IActionResult ApplicationUserDelete(int applicationId)
        {
            var entity = _usersApplications.GetAll().Where(c => c.Id == applicationId).FirstOrDefault();
            entity.isDeleted = true;
            _usersApplications.Update(entity);

            _notyf.Success($"The User Application is successfully deleted.");
            return RedirectToAction("ApplicationsList");
        }

        [HttpGet]
        public IActionResult DefineServiceToCompanyList()
        {
            var defineServiceModel = new CompaniesServiceModel()
            {
                Companies = _companyService.GetAll(),
                Services = _serviceService.GetAll(),
                CompaniesService = _companiesServicesService.GetAll()
            };
            return View(defineServiceModel);
        }
        [HttpGet]
        public IActionResult DefineServiceToCompanySet(int? companyId)
        {
            if (companyId == null)
            {
                return NotFound();
            }
            var companies = _companyService.GetById((int)companyId);
            var services = _serviceService.GetAll();

            return View(new CompaniesServiceModel()
            {
                CompanyId = (int)companyId,
                CompanyName = companies.Name,
                Services = services
            });
        }
        [HttpPost]
        public IActionResult DefineServiceToCompanySet(CompaniesServiceModel model, string save, string delete)
        {
            if (!string.IsNullOrEmpty(save))
            {
                var serviceId = Request.Form["serviceId"].ToString();
                var companyId = Request.Form["companyId"].ToString();
                if (string.IsNullOrEmpty(serviceId))
                {
                    _notyf.Information("Do not leave the fields blank.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }
                if (string.IsNullOrEmpty(companyId))
                {
                    _notyf.Information("Do not leave the fields blank.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }

                var companyServices = new CompaniesService()
                {
                    CompanyId = Convert.ToInt32(companyId),
                    ServiceId = Convert.ToInt32(serviceId)
                };
                var result = _companiesServicesService.GetAll().Where(c => c.ServiceId == Convert.ToInt32(serviceId) && c.CompanyId == Convert.ToInt32(companyId));
                if (result.Count() > 0)
                {
                    _notyf.Warning("Company already has this service.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }
                _companiesServicesService.Create(companyServices);

                _notyf.Success("Paired successfully.");
                return RedirectToAction("DefineServiceToCompanyList");
            }
            else if (!string.IsNullOrEmpty(delete))
            {
                var serviceId = Request.Form["serviceId"].ToString();
                var companyId = Request.Form["companyId"].ToString();
                if (string.IsNullOrEmpty(serviceId))
                {
                    _notyf.Warning("Do not leave the fields blank.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }
                if (string.IsNullOrEmpty(companyId))
                {
                    _notyf.Warning("Do not leave the fields blank.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }
                var result = _companiesServicesService.GetAll().Where(c => c.CompanyId == Convert.ToInt32(companyId) && c.ServiceId == Convert.ToInt32(serviceId)).FirstOrDefault();
                if (result != null)
                {

                    _companiesServicesService.Delete(result);

                    _notyf.Success("Paired successfully.");
                    return RedirectToAction("DefineServiceToCompanyList");
                }
                _notyf.Information("Service Not Found In Company");
                return RedirectToAction("DefineServiceToCompanyList");
            }
            return RedirectToAction("DefineServiceToCompanyList");

        }

        [HttpGet]
        [Obsolete]
        public IActionResult RequestList()
        {

            return View(new RequestsListModel()
            {
                Requests = _requestService.GetAll(),
                Users = _userManager.Users.ToList(),
                Services = _serviceService.GetAll(),
                CompaniesServices = _companiesServicesService.GetAll()

            });
        }
        [HttpGet]
        public IActionResult EmployeeRequestList()
        {
            var employeeId = _userManager.GetUserId(HttpContext.User);

            return View(new RequestsListModel()
            {
                Requests = _requestService.GetAll(),
                Users = _userManager.Users.ToList(),
                Services = _serviceService.GetAll(),
                EmployeeId = employeeId,
                CompaniesServices = _companiesServicesService.GetAll(),
                EmployeeRequests = _employeeRequestsService.GetAll()
            });
        }


        [HttpGet]
        public async Task<IActionResult> RequestDetail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var request = _requestService.GetById((int)id);
            if (request == null)
            {
                return NotFound();
            }

            var files = _fileUploadService.GetAll();
            var user = await _userManager.FindByIdAsync(request.UserId);
            var departments = _departmentService.GetAll();
            var requestResponses = _requestResponseService.GetAll()
                .Where(c => c.RequestId == id)
                .OrderBy(c => c.ResponseDate)
                .ToList();

            var model = new RequestsModel()
            {
                EnumRequestStatus = request.RequestStatus,
                Request = request,
                Departments = departments,
                FilesDownload = files,
                DepartmentId = request.DepartmentId,
                Services = _serviceService.GetAll(),
                CompaniesServices = _companiesServicesService.GetAll(),
                EmployeeDepartments = _employeeDepartmentService.GetAll(),
                RequestDepartments = _requestDepartmentService.GetAll(),
                RequestResponses = requestResponses,
                EmployeeRequests = _employeeRequestsService.GetAll(),
                Users = _userManager.Users.ToList(),
                User = user
            };
            if (model.EmployeeDepartments == null)
            {
                _notyf.Warning("Please contact you adviser and say set employee to department.");
                return RedirectToAction("RequestList");
            }

            return View(model);
        }
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> RequestDetail(RequestsModel response, int? requestId, string closeRequest, string openRequest, string sendResponse, string defineEmployeeToRequest, string defineServiceToRequest, string defineDepartmentToRequest, string sendDescriptionResponse)
        {
            string? employeeId = Request.Form["employeeId"].ToString();
            string? departmentId = Request.Form["departmentId"].ToString();
            string? serviceId = Request.Form["serviceId"].ToString();
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
            if (!string.IsNullOrEmpty(defineDepartmentToRequest))
            {
                if (string.IsNullOrEmpty(defineDepartmentToRequest))
                {
                    _notyf.Warning("Please select a Department.");
                    return RedirectToAction("RequestDetail");
                }
                var currentRequest = _requestService.GetById((int)requestId);
                var currentDepartment = _requestDepartmentService.GetAll().Where(c => c.RequestId == currentRequest.Id).FirstOrDefault();
                currentRequest.DepartmentId = Convert.ToInt32(departmentId);
                _requestService.Update(currentRequest);


                if (currentDepartment.DepartmentId != Convert.ToInt32(departmentId))
                {
                    var requestDepartment = new RequestDepartment()
                    {
                        DepartmentId = Convert.ToInt32(departmentId),
                        AddedDate = DateTime.Now,
                        RequestId = (int)requestId
                    };
                    _requestDepartmentService.Create(requestDepartment);
                    DelayedJobs.SendMailToDepartmentEmployeeForUnAnsweredRequests(requestDepartment.RequestId);
                }
                else
                {
                    _notyf.Warning("Request already in selected department.");
                    return RedirectToAction("RequestDetail");
                }

                _notyf.Success("You updated Department to Request.");
                return RedirectToAction("RequestDetail");
            }
            if (!string.IsNullOrEmpty(defineEmployeeToRequest))
            {
                if (string.IsNullOrEmpty(employeeId))
                {
                    _notyf.Warning("Please select a Employee.");
                    return RedirectToAction("RequestDetail");
                }
                var defineEmployeeRequest = new EmployeeRequests()
                {
                    AddedDate = DateTime.Now,
                    EmployeeId = employeeId,
                    RequestId = (int)requestId
                };
                var employeeReuqests = _employeeRequestsService.GetAll();
                if (employeeReuqests.Count > 0)
                {
                    var isRequestHasEmployee = employeeReuqests.Any(c => c.RequestId == requestId);

                    if (!isRequestHasEmployee)
                    {
                        _employeeRequestsService.Create(defineEmployeeRequest);
                        _notyf.Success("Employee has been Defined To Request. Result Success.");
                        return RedirectToAction("RequestDetail");
                    }
                    else
                    {
                        var employeeRequest = employeeReuqests.Where(c => c.RequestId == requestId).FirstOrDefault();
                        employeeRequest.EmployeeId = employeeId;
                        employeeRequest.AddedDate = DateTime.Now;
                        await _employeeRequestsService.UpdateAsync(employeeRequest);
                        _notyf.Success("Employee has been Defined To Request. Successfuly Updated.");
                        DelayedJobs.SendMailToEmployeeForUnAnsweredRequests((int)requestId, employeeId);
                        return RedirectToAction("RequestDetail");
                    }

                }
                else
                {
                    _employeeRequestsService.Create(defineEmployeeRequest);
                    DelayedJobs.SendMailToEmployeeForUnAnsweredRequests((int)requestId, employeeId);
                    _notyf.Success("Employee has been Defined To Request. Result Success.");
                    return RedirectToAction("RequestDetail");
                }

                _notyf.Warning("Something Went Wrong.");
                return RedirectToAction("RequestDetail");
            }
            if (requestId != null && !string.IsNullOrEmpty(defineServiceToRequest))
            {
                var currentRequest = _requestService.GetById((int)requestId);
                var currentCompanyService = _companiesServicesService.GetAll().Where(c => c.ServiceId == Convert.ToInt32(serviceId)).FirstOrDefault();
                var currentRequestDepartment = _serviceService.GetAll().Where(c => c.Id == currentCompanyService.ServiceId).FirstOrDefault();


                currentRequest.CompaniesServiceId = currentCompanyService.Id;
                currentRequest.DepartmentId = (int)currentRequestDepartment.DepartmentId;
                _requestService.Update(currentRequest);

                _notyf.Warning("Define Service To Request Complete");
                return RedirectToAction("RequestDetail");
            }
            if (!string.IsNullOrEmpty(closeRequest))
            {
                var closedRequest = _requestService.GetById((int)requestId);
                closedRequest.RequestStatus = Entity.Request.EnumRequestStatus.Closed;
                _requestService.Update(closedRequest);
                _notyf.Success("Request successfuly closed.");
                return RedirectToAction("RequestDetail");
            }
            if (!string.IsNullOrEmpty(openRequest))
            {
                var openedRequest = _requestService.GetById((int)requestId);
                openedRequest.RequestStatus = Entity.Request.EnumRequestStatus.Waiting;
                _requestService.Update(openedRequest);
                _notyf.Success("Request successfuly reopened.");
                return RedirectToAction("RequestDetail");
            }
            if (!string.IsNullOrEmpty(sendResponse))
            {
                var entity = new RequestResponse()
                {
                    ResponseDate = DateTime.Now,
                    Response = sendDescriptionResponse,
                    ResponseType = RequestResponse.EnumResponseType.Receiver,
                    RequestId = (int)requestId
                };
                if (string.IsNullOrEmpty(sendDescriptionResponse))
                {
                    _notyf.Warning("Response not null.");
                    return RedirectToAction("RequestDetail");
                }
                if (_requestResponseService.Create(entity))
                {
                    _notyf.Success("You Added a new response.");
                    return RedirectToAction("RequestDetail");
                }
                _notyf.Warning("Response not send.");
                return RedirectToAction("RequestDetail");
            }

            return RedirectToAction("RequestDetail");

        }

        public IActionResult SearchRequest(string queryString, Request.EnumRequestStatus requestStatId, string serviceName)
        {
            return View(new RequestsListModel()
            {
                Requests = _requestService.GetSearchResult(queryString, null, requestStatId, serviceName),
                Users = _userManager.Users.ToList(),
                Services = _serviceService.GetAll(),
                CompaniesServices = _companiesServicesService.GetAll()
            });
        }

        [HttpGet]
        [Obsolete]
        public IActionResult LogList()
        {
            //Clearlogs
            var logs = _logsService.GetAll();
            RecurringJobs.ClearLogs(logs);
            return View(new LogsViewModel()
            {
                Logs = _logsService.GetAll()
            });
        }
    }

}

