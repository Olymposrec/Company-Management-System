using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(Service entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Services.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(Service entity)
        {
            _unitOfWork.Services.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Service> GetAll()
        {
            return _unitOfWork.Services.GetAll();
        }
        public async Task<List<Service>> GetAllAsync()
        {
            return await _unitOfWork.Services.GetAllAsync();
        }

        public Service GetById(int id)
        {
            return _unitOfWork.Services.GetById(id);
        }

        public Service GetByIdWithUsers(int id)
        {
            return _unitOfWork.Services.GetByIdWithUsers(id);
        }

        public bool Update(Service entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Services.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        public async Task UpdateAsync(Service entity)
        {
            if (Validation(entity))
            {
                await _unitOfWork.Services.UpdateAsync(entity);
                await _unitOfWork.SaveAsync();
            }
        }

        public bool Validation(Service entity)
        {
            var isValid = true;           
            if (string.IsNullOrEmpty(entity.ServiceName))
            {
                ErrorMessage += "Service Name is required.";
                return false;
            }
            else if (entity.ServiceName.Length <= 3 || entity.ServiceName.Length >= 30)
            {
                ErrorMessage += "Service Name must be between 3-30";
                return false;
            }
            if (entity.ServiceDescription.Length <= 5 || entity.ServiceDescription.Length >= 30)
            {
                ErrorMessage += "Service Description must be between 5-30 character";
                return false;
            }
            return isValid;
        }
    }
}
