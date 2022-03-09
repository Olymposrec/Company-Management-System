using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCompanyRepository : EfCoreGenericRepository<Company>, ICompanyRepository
    {
        public EfCoreCompanyRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }
        public Company GetByIdWithUsers(int id)
        {
            return BusinessAppContext.Companies.Where(f => f.Id == id).FirstOrDefault();
        }

        public int GetIdWithName(string firmName)
        {
            return BusinessAppContext.Companies.Where(c => c.Name.ToLower().Trim() == firmName.ToLower().Trim()).Select(c => c.Id).FirstOrDefault();
        }
    }
}
