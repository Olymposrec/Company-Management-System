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
    public class EmployeeRequestsScheduleJobManager
    {
        private readonly IEmailSender _mailService;
        private IEmployeeRequestsService _employeeRequestsService;
        private IRequestResponseService _requestResponseService;
        private IRequestService _requestService;
        private UserManager<User> _userManager;
        public EmployeeRequestsScheduleJobManager(IEmailSender mailService
           , IEmployeeRequestsService employeeRequestsService
            , IRequestResponseService requestResponseService
            ,IRequestService requestService
           , UserManager<User> userManager)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _employeeRequestsService = employeeRequestsService;
            _userManager = userManager;
            _requestResponseService = requestResponseService;
            _requestService = requestService;

        }

        public async Task Process(int requestId, string employeeId)
        {
            var employeeRequest = _employeeRequestsService.GetByEmployeeIdAndRequestId(employeeId, requestId);
            var requestResponses = _requestResponseService.GetAll();
            var request = _requestService.GetById(requestId);

            if ((DateTime.Now - request.RequestDate.Date).TotalDays > 3 && !requestResponses.Exists(c => c.RequestId == requestId))
            {
                if ((DateTime.Now - employeeRequest.AddedDate.Date).TotalDays > 3)
                {
                    var user = _userManager.FindByIdAsync(employeeRequest.EmployeeId);
                    await _mailService.SendEmailAsync(user.Result.Email, "Unanswered Request "
                        + $" {request.Title}",
                        "<div class='row text-center'><div class='col-sm-4 text-center'></div><div class='col-sm-4 text-center'><h3 class='text-center'>Company App</h3><hr><h5 class='text-center'>Employee Has Unanswered Request</h5><hr><p class='text-center'>Please Check Your Request and Return The Customer.</p></div><div class='col-sm-4'></div></div>");
                }
            }
        }
    }
}
