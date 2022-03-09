using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class EmployeeDepartmentManager : IEmployeeDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeDepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(EmployeeDepartment entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.EmployeeDepartments.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(EmployeeDepartment entity)
        {
            _unitOfWork.EmployeeDepartments.Delete(entity);
            _unitOfWork.Save();
        }

        public bool FindByDepartmentAndEmployeeId(int departmentId, string userId)
        {
            return _unitOfWork.EmployeeDepartments.FindByDepartmentAndEmployeeId(departmentId, userId);
        }

        public List<EmployeeDepartment> GetAll()
        {
            return _unitOfWork.EmployeeDepartments.GetAll();
        }   

        public EmployeeDepartment GetById(int id)
        {
            return _unitOfWork.EmployeeDepartments.GetById(id);
        }

        public bool Update(EmployeeDepartment entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.EmployeeDepartments.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return true;
        }

        public bool Validation(EmployeeDepartment entity)
        {
            var isValid = true;
            if (entity.DepartmentId == null)
            {
                ErrorMessage += "Department Id not be null";
                return false;
            }
            if (entity.EmployeeId == null)
            {
                ErrorMessage += "Employee Id Id not be null";
                return false;
            }

            return isValid;
        }
    }
}
