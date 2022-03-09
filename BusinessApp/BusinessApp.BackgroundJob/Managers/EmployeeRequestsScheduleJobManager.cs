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
    public class EmployeeRequestsScheduleJobManager
    {
        private readonly IEmailSender _mailService;
        private IEmployeeRequestsService _employeeRequestsService;
        private IRequestResponseService _requestResponseService;
        private IRequestService _requestService;
        private UserManager<IdentityUser> _userManager;
        public EmployeeRequestsScheduleJobManager(IEmailSender mailService
           , IEmployeeRequestsService employeeRequestsService
            , IRequestResponseService requestResponseService
            ,IRequestService requestService
           , UserManager<IdentityUser> userManager)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _employeeRequestsService = employeeRequestsService;
            _userManager = userManager;
            _requestResponseService = requestResponseService;
            _requestService = requestService;

        }

        public async Task Process(int requestId)
        {
            var request = _requestService.GetById(requestId);
            var employeeRequests = _employeeRequestsService.GetAll().Where(c => c.RequestId == requestId);
            var requestResponseIsExists = _requestResponseService.GetAll().Any(c => c.RequestId == requestId);
            var unAnsweredWithinThreeDays = employeeRequests.Where(c => c.AddedDate > DateTime.Now.AddDays(-3));
            if (!requestResponseIsExists) 
            {
                if (unAnsweredWithinThreeDays.Count() > 0)
                {                  

                    foreach(var employee in employeeRequests)
                    {
                        var user = _userManager.FindByIdAsync(employee.EmployeeId);
                        await _mailService.SendEmailAsync(user.Result.Email, "UnAnswered Request "+$" {request.Title}", "Please Check Your Request And Answer");
                    }
                }
            }
            
        }
    }
}
