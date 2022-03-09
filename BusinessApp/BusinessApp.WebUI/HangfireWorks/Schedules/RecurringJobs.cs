using BusinessApp.Entity;
using BusinessApp.WebUI.HangfireWorks.Managers.RecurringJobs;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.HangfireWorks.Schedules
{
    public static class RecurringJobs
    {
        [Obsolete]
        public static void ClearLogs(List<Log> Logs)
        {
            Hangfire.RecurringJob.RemoveIfExists(nameof(ClearLogs));
            Hangfire.RecurringJob.AddOrUpdate<ClearLogsScheduleJobManager>(
                job => job.Process(Logs),
                "* * */3 * *"
            );
        }
    }
}
