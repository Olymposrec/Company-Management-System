using BusinessApp.WebUI.HangfireWorks.Managers.DelayedJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.WebUI.HangfireWorks.Schedules
{
    public static class DelayedJobs
    {
        [Obsolete]
        public static void SendMailToEmployeeForUnAnsweredRequests(int requestId, string employeeId)
        {
            Hangfire.BackgroundJob.Schedule<EmployeeRequestsScheduleJobManager>(
                job => job.Process(requestId, employeeId),
                TimeSpan.FromDays(3)
            );
        }
        [Obsolete]
        public static void SendMailToDepartmentEmployeeForUnAnsweredRequests(int requestId)
        {
            Hangfire.BackgroundJob.Schedule<RequestDepartmentsScheduleJobManager>(
              job => job.Process(requestId),
              TimeSpan.FromDays(5)
          );
        }
    }
}
