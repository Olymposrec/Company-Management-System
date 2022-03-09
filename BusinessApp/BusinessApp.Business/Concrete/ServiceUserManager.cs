using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class ServiceUserManager : IServiceUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceUserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(ServiceUser entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.ServiceUsers.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(ServiceUser entity)
        {
            _unitOfWork.ServiceUsers.Delete(entity);
            _unitOfWork.Save();
        }

        public List<ServiceUser> GetAll()
        {
            return _unitOfWork.ServiceUsers.GetAll();
        }

        public ServiceUser GetById(int id)
        {
            return _unitOfWork.ServiceUsers.GetById(id);
        }

        public bool Update(ServiceUser entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.ServiceUsers.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(ServiceUser entity)
        {
            var isValid = true;
            if (entity.ServiceId == 0)
            {
                ErrorMessage += "Service Id Required.";
                return false;
            }
            if (entity.UserId == null)
            {
                ErrorMessage += "Service Id Required.";
                return false;
            }

            return isValid;
        }
    }
}
