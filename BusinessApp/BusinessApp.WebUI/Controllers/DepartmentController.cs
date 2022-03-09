using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessApp.Business.Abstract;
using BusinessApp.Entity;
using BusinessApp.WebUI.Extensions;
using BusinessApp.WebUI.Identity;
using BusinessApp.WebUI.Models;
using BusinessApp.WebUI.Models.DepartmentsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<DepartmentController> _logger;

        private IDepartmentService _departmentService;
        private IServiceService _serviceService;
        private UserManager<User> _userManager;
        public DepartmentController(IDepartmentService departmentService
            , IServiceService serviceService
            , INotyfService notyf
            ,UserManager<User> userManager
            , ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _serviceService = serviceService;
            _notyf = notyf;
            _logger = logger;
            

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult DepartmentList()
        {
            return View(new DepartmentModel()
            {
                Departments = _departmentService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult DepartmentCreate()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new DepartmentModel()
            {
                Departments = _departmentService.GetAll(),
                companyId=user.CompanyId
            });
        }

        [HttpPost]
        public IActionResult DepartmentCreate(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = model.Name,
                    isDefault = false
                };

                if (_departmentService.Create(department))
                {
                    _notyf.Success("You Added a new Department.");

                    return RedirectToAction("DepartmentCreate");
                }

                _notyf.Error(_departmentService.ErrorMessage);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DepartmentEdit(int? id)
        {
            var department = _departmentService.GetById((int)id);
            return View(new DepartmentModel()
            {
                Name= department.Name
            });
        }

        [HttpPost]
        public IActionResult DepartmentEdit(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Id = model.Id,
                    Name = model.Name
                };

                if (_departmentService.Update(department))
                {
                    _notyf.Success("You updated Department.");

                    return RedirectToAction("DepartmentCreate");
                }

                _notyf.Error(_departmentService.ErrorMessage);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DefineDepartmentToDefault(int? departmentId)
        {
            int defaultDepartmentId = 0;
            if (departmentId == null)
            {
                _notyf.Warning("Please Select a department.");
                return RedirectToAction("DepartmentCreate");
            }

            var departments = await _departmentService.GetAllAsync();
            foreach (var department in departments)
            {
                var newDepartment = department;
                newDepartment.isDefault = false;
                await _departmentService.UpdateAsync(newDepartment);
            }

            foreach (var department in departments)
            {
                var newDepartment = department;

                if (newDepartment.Id == departmentId)
                {
                    newDepartment.isDefault = true;
                    defaultDepartmentId = newDepartment.Id;
                    await _departmentService.UpdateAsync(newDepartment);
                }
            }

            var services = await _serviceService.GetAllAsync();
            foreach (var service in services)
            {
                if (service.DepartmentId == null)
                {
                    var newService = service;
                    newService.DepartmentId = defaultDepartmentId;
                    await _serviceService.UpdateAsync(newService);
                }
                
            }

            return RedirectToAction("DepartmentCreate");
        }

        [HttpPost]
        public IActionResult DepartmentDelete(int departmentId)
        {
            var entity = _departmentService.GetById(departmentId);
            if (entity != null)
            {
                entity.isDeleted = true;
                _departmentService.Update(entity);

            }

            _notyf.Success("You delete a Department.");
            return RedirectToAction("DepartmentCreate");
        }
    }
}
