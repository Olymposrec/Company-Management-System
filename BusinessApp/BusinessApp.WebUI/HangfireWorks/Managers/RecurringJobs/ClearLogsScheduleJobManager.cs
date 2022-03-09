using BusinessApp.Business.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.HangfireWorks.Managers.RecurringJobs
{
    public class ClearLogsScheduleJobManager
    {
        private ILogsService _logsService;

        public ClearLogsScheduleJobManager(ILogsService logsService)
        {
            _logsService = logsService;
        }
        public async Task Process(List<Log> Logs)
        {
            foreach(var log in Logs)
            {
                _logsService.Delete(log);
            }
        }
    }
}
