using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class RequestDepartmentManager : IRequestDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestDepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(RequestDepartment entity)
        {
            if (Validation(entity))
            {

                _unitOfWork.RequestDepartments.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(RequestDepartment entity)
        {
            _unitOfWork.RequestDepartments.Delete(entity);
            _unitOfWork.Save();
        }

        public List<RequestDepartment> GetAll()
        {
            return _unitOfWork.RequestDepartments.GetAll();
        }

        public RequestDepartment GetById(int id)
        {
            return _unitOfWork.RequestDepartments.GetById(id);
        }

        public bool Update(RequestDepartment entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.RequestDepartments.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(RequestDepartment entity)
        {           
            return true;
        }
    }
}
