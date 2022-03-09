using BusinessApp.Business.Abstract;
using BusinessApp.WebUI.EmailServices;
using BusinessApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.HangfireWorks.Managers.DelayedJobs
{
    public class RequestDepartmentsScheduleJobManager
    {
        private readonly IEmailSender _mailService;
        private IRequestDepartmentService _requestDepartmentService;
        private IRequestResponseService _requestResponseService;
        private IRequestService _requestService;
        private IEmployeeDepartmentService _employeeDepartmentService;
        private UserManager<User> _userManager;

        public RequestDepartmentsScheduleJobManager(IEmailSender mailService
            , IRequestDepartmentService requestDepartmentService
            , IRequestResponseService requestResponseService
            , IRequestService requestService
            , IEmployeeDepartmentService employeeDepartmentService
            , UserManager<User> userManager)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _requestDepartmentService = requestDepartmentService;
            _userManager = userManager;
            _requestService = requestService;
            _requestResponseService = requestResponseService;
            _employeeDepartmentService = employeeDepartmentService;

        }

        public async Task Process(int requestId)
        {
            var departmentEmployees = _employeeDepartmentService.GetAll();
            var requestDepartments = _requestDepartmentService.GetAll();
            var requestResponses = _requestResponseService.GetAll();
            var request = _requestService.GetById(requestId);

            if ((DateTime.Now - request.RequestDate.Date).TotalDays > 5 && !requestResponses.Exists(c => c.RequestId == requestId))
            {
                foreach (var employee in departmentEmployees)
                {
                    if (request.DepartmentId == employee.DepartmentId)
                    {
                        var user = _userManager.FindByIdAsync(employee.EmployeeId);
                        await _mailService.SendEmailAsync(user.Result.Email, "Unanswered Request "
                            + $" {request.Title}",
                            "<div class='row text-center'><div class='col-sm-4 text-center'></div><div class='col-sm-4 text-center'><h3 class='text-center'>Company App</h3><hr><h5 class='text-center'>Department Has UnAnswered Request</h5><hr><p class='text-center'>Please Check Your Request and Return The Customer.</p></div><div class='col-sm-4'></div></div>");
                    }

                }
            }
        }
    }
}
