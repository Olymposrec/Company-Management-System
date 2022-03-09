using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCompaniesServiceRepository : EfCoreGenericRepository<CompaniesService>, ICompaniesServiceRepository
    {
        public EfCoreCompaniesServiceRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public CompaniesService GetByCompanyAndServiceId(int companyId, int serviceId)
        {
            return BusinessAppContext.CompaniesService.Where(c => c.CompanyId == companyId && c.ServiceId==serviceId).FirstOrDefault();
        }

        public List<CompaniesService> GetByFirmId(int id)
        {
            return BusinessAppContext.CompaniesService.Where(c => c.CompanyId == id).ToList();
        }

        public Service GetByServiceId(int id)
        {
            return BusinessAppContext.Services.Where(c => c.Id == id).FirstOrDefault();
        }

        public CompaniesService GetFirmsServiceById(int id)
        {
            return BusinessAppContext.CompaniesService.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
