using BusinessApp.Business.Abstract;
using BusinessApp.WebUI.EmailServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.BackgroundJob.Managers
{
    public class RequestDepartmentsScheduleJobManager
    {
        private readonly IEmailSender _mailService;
        private IRequestDepartmentService _requestDepartmentService;
        private IRequestResponseService _requestResponseService;
        private IRequestService _requestService;
        private IEmployeeDepartmentService _employeeDepartmentService;
        private UserManager<IdentityUser> _userManager;

        public RequestDepartmentsScheduleJobManager(IEmailSender mailService
            , IRequestDepartmentService requestDepartmentService
            , IRequestResponseService requestResponseService
            , IRequestService requestService
            , IEmployeeDepartmentService employeeDepartmentService
            , UserManager<IdentityUser> userManager)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _requestDepartmentService = requestDepartmentService;
            _userManager = userManager;
            _requestService = requestService;
            _requestResponseService = requestResponseService;
            _requestDepartmentService = requestDepartmentService;
            _employeeDepartmentService = employeeDepartmentService;

        }

        public async Task Process(int requestId)
        {
            var request = _requestService.GetById(requestId);
            var requestDepartments = _requestDepartmentService.GetAll().Where(c => c.RequestId == requestId);
            var requestResponseIsExists = _requestResponseService.GetAll().Any(c => c.RequestId == requestId);
            var unAnsweredWithinThreeDays = requestDepartments.Where(c => c.AddedDate > DateTime.Now.AddDays(-5));

            var employeesDepartment = _employeeDepartmentService.GetAll();
            if (!requestResponseIsExists)
            {
                if (unAnsweredWithinThreeDays.Count() > 0)
                {

                    foreach (var employeesOfDepartments in employeesDepartment)
                    {
                        var user = _userManager.FindByIdAsync(employeesOfDepartments.EmployeeId);
                        await _mailService.SendEmailAsync(user.Result.Email, "UnAnswered Request " + $" {request.Title}", "Please Check Your Request And Answer");
                    }
                }
            }
        }
    }
}
