using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreServiceRepository : EfCoreGenericRepository<Service>, IServiceRepository
    {
        public EfCoreServiceRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }
        public Service GetByIdWithUsers(int id)
        {
            return BusinessAppContext.Services.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
