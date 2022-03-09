using BusinessApp.BackgroundJob.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.BackgroundJob.Schedules
{
    public static class DelayedJobs
    {
        [Obsolete]
        public static void SendMailToEmployeeForUnAnsweredRequests(int requestId)
        {
            Hangfire.BackgroundJob.Schedule<RequestDepartmentsScheduleJobManager>(
                job => job.Process(requestId),
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
