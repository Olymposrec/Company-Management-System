using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreUsersApplicationRepository : EfCoreGenericRepository<UsersApplication>, IUsersApplicationRepository
    {
        public EfCoreUsersApplicationRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public UsersApplication GetByStringId(string id)
        {
            return BusinessAppContext.UsersApplications.Where(c => c.UserId == id).FirstOrDefault();
        }
    }
}
