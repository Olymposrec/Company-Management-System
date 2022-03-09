using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface ICompaniesServicesService:IValidator<CompaniesService>
    {
        CompaniesService GetById(int id);
        CompaniesService GetByCompanyAndServiceId(int companyId, int serviceId);
        List<CompaniesService> GetByFirmId(int id);
        CompaniesService GetFirmsServiceById(int id);
        Service GetByServiceId(int id);
        List<CompaniesService> GetAll();
        bool Create(CompaniesService entity);
        bool Update(CompaniesService entity);
        void Delete(CompaniesService entity);
    }
}
