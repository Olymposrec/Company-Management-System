using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(Company entity)
        {
            var uniqTaxNumber = _unitOfWork.Companies.GetAll();
            if (Validation(entity))
            {
                if (entity.TaxNumber != null && entity.PhoneNumber != null && entity.Email != null)
                {
                    foreach (var item in uniqTaxNumber)
                    {
                        if (item.TaxNumber == entity.TaxNumber)
                        {
                            ErrorMessage += "This Tax Number Already Using.";
                            return false;
                        }
                        if (item.PhoneNumber == entity.PhoneNumber)
                        {
                            ErrorMessage += "This Phone Number Already Using.";
                            return false;
                        }
                        if (item.Email == entity.Email)
                        {
                            ErrorMessage += "This Email Already Using.";
                            return false;
                        }
                    }
                }


                _unitOfWork.Companies.Create(entity);
                _unitOfWork.Save();
                return true;              
            }
            return false;
        }

        public void Delete(Company entity)
        {
            _unitOfWork.Companies.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Company> GetAll()
        {
            return _unitOfWork.Companies.GetAll();
        }

        public Company GetById(int id)
        {
            return _unitOfWork.Companies.GetById(id);
        }

        public Company GetByIdWithUsers(int id)
        {
            return _unitOfWork.Companies.GetByIdWithUsers(id);
        }

        public int GetIdWithName(string firmName)
        {
            return _unitOfWork.Companies.GetIdWithName(firmName);
        }

        public bool Update(Company entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Companies.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Company entity)
        {
            var isValid = true;
          
            if (entity.TaxNumber.Length != 11)
            {
                ErrorMessage += "Tax Number Length must be equal to 11";
                return false;              
            }
            
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Name is required.";
                return false;
            }else if (entity.Name.Length <= 3 || entity.Name.Length >= 30 )
            {
                ErrorMessage += "Name must be between 3-30";
                return false;
            }
            if (!entity.Email.Contains("@"))
            {
                ErrorMessage += "Email must containe '@'";
                return false;
            }
            return isValid;
        }
    }
}
