using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class CompaniesServiceManager : ICompaniesServicesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompaniesServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(CompaniesService entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.CompaniesService.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(CompaniesService entity)
        {
            _unitOfWork.CompaniesService.Delete(entity);
            _unitOfWork.Save();
        }

        public List<CompaniesService> GetAll()
        {
            return _unitOfWork.CompaniesService.GetAll();
        }

        public List<CompaniesService> GetByFirmId(int id)
        {
            return _unitOfWork.CompaniesService.GetByFirmId(id);
        }

        public CompaniesService GetFirmsServiceById(int id)
        {
            return _unitOfWork.CompaniesService.GetFirmsServiceById(id);
        }

        public CompaniesService GetById(int id)
        {
            return _unitOfWork.CompaniesService.GetById(id);
        }
      
        public Service GetByServiceId(int id)
        {
            return _unitOfWork.CompaniesService.GetByServiceId(id);
        }      

        public bool Update(CompaniesService entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.CompaniesService.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return true;
        }

        public bool Validation(CompaniesService entity)
        {
            var isValid = true;
            if (entity.CompanyId == null)            {
                ErrorMessage += "Tax Number Length must be equal to 11";
                return false;
            }
            if (entity.ServiceId == null)
            {
                ErrorMessage += "Tax Number Length must be equal to 11";
                return false;
            }

            return isValid;
        }

        public CompaniesService GetByCompanyAndServiceId(int companyId, int serviceId)
        {
            return _unitOfWork.CompaniesService.GetByCompanyAndServiceId(companyId,serviceId);
        }
    }
}
