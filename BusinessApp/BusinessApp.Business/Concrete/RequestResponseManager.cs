using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class RequestResponseManager : IRequestResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestResponseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(RequestResponse entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.RequestResponses.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(RequestResponse entity)
        {
            _unitOfWork.RequestResponses.Delete(entity);
            _unitOfWork.Save();
        }

        public List<RequestResponse> GetAll()
        {
            return _unitOfWork.RequestResponses.GetAll();
        }

        public RequestResponse GetById(int id)
        {
            return _unitOfWork.RequestResponses.GetById(id);
        }

        public bool Update(RequestResponse entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.RequestResponses.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(RequestResponse entity)
        {
            return true;
        }
    }
}
