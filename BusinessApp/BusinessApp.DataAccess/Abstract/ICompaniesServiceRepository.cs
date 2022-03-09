using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Abstract
{
    public interface ICompaniesServiceRepository: IRepository<CompaniesService>
    {
        Service GetByServiceId(int id);
        List<CompaniesService> GetByFirmId(int id);
        CompaniesService GetFirmsServiceById(int id);
        CompaniesService GetByCompanyAndServiceId(int companyId,int serviceId);

    }
}
