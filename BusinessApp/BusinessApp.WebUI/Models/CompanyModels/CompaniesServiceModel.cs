using BusinessApp.Entity;
using System.Collections.Generic;

namespace BusinessApp.WebUI.Models.CompanyModels
{
    public class CompaniesServiceModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Service> Services{ get; set; }
        public List<Entity.Company> Companies{ get; set; }
        public List<CompaniesService> CompaniesService { get; set; }
    }

}
