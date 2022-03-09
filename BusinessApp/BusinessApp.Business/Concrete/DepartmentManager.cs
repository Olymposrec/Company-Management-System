using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(Department entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Departments.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(Department entity)
        {
            _unitOfWork.Departments.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Department> GetAll()
        {
            return _unitOfWork.Departments.GetAll();
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public Department GetById(int id)
        {
            return _unitOfWork.Departments.GetById(id);
        }

        public bool Update(Department entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Departments.Update(entity);
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Department entity)
        {
            if (Validation(entity))
            {
                await _unitOfWork.Departments.UpdateAsync(entity);
            }
        }

        public bool Validation(Department entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.Name)){
                ErrorMessage += "Department is required.";
                return false;
            }
            return isValid;
        }
    }
}
