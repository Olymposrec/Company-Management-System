using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Concrete
{
    public class UsersApplicationManager: IUsersApplicaitonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersApplicationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; }

        public bool Create(UsersApplication entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.UsersApplications.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(UsersApplication entity)
        {
            _unitOfWork.UsersApplications.Delete(entity);
            _unitOfWork.Save();
        }

        public List<UsersApplication> GetAll()
        {
            return _unitOfWork.UsersApplications.GetAll();
        }

        public UsersApplication GetById(int id)
        {
            return _unitOfWork.UsersApplications.GetById(id);
        }

        public async Task<UsersApplication> GetByIdAsync(int id)
        {
            return await _unitOfWork.UsersApplications.GetByIdAsync(id);
        }

        public UsersApplication GetByStringId(string applicationId)
        {
            return _unitOfWork.UsersApplications.GetByStringId(applicationId);
        }

        public bool Update(UsersApplication entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.UsersApplications.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(UsersApplication entity)
        {
            await _unitOfWork.UsersApplications.UpdateAsync(entity);
        }

        public bool Validation(UsersApplication entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.CompanyName))
            {
                ErrorMessage += "Firm Name Required";
                return false;
            }
           
            return isValid;
        }
    }
}
