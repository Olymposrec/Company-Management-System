using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(Request entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Requests.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public async Task CreateAsync(Request entity)
        {
            await _unitOfWork.Requests.CreateAsync(entity);
        }

        public void Delete(Request entity)
        {
            _unitOfWork.Requests.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Request> GetAll()
        {
            return _unitOfWork.Requests.GetAll();
        }

        public Request GetById(int id)
        {
            return _unitOfWork.Requests.GetById(id);
        }

        public Request GetByUserId(string userId)
        {
            return _unitOfWork.Requests.GetByUserId(userId);
        }

        public List<Request> GetSearchResult(string q)
        {
            return _unitOfWork.Requests.GetSearchResult(q);
        }

        public List<Request> GetSearchResult(string searchString, int? companyServiceserviceId, Request.EnumRequestStatus requestStatus,string serviceName)
        {
            return _unitOfWork.Requests.GetSearchResult(searchString, companyServiceserviceId, requestStatus, serviceName);
        }

        public bool Update(Request entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Requests.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Request entity)
        {
            var isValid = true;
            if (entity.Description.Length <= 5 || entity.Description.Length >= 250)
            {
                ErrorMessage += "Service Description must be between 5-250 character";
                return false;
            }
            return isValid;
        }
    }
}
