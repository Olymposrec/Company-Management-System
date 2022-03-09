using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreLogRepository: EfCoreGenericRepository<Log>, ILogsRepository
    {
        public EfCoreLogRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public void DeleteAll(List<Log> entity)
        {
            BusinessAppContext.Logs.RemoveRange(entity);
        }
    }
}
