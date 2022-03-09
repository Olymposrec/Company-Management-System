using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreEmployeeRequestsRepository: EfCoreGenericRepository<EmployeeRequests>, IEmployeeRequestsRepository
    {
        public EfCoreEmployeeRequestsRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public EmployeeRequests GetByEmployeeIdAndRequestId(string employeeId, int requestId)
        {
            return BusinessAppContext.EmployeeRequests.Where(c => c.EmployeeId == employeeId && c.RequestId==requestId).FirstOrDefault();
        }
    }
}
