using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Concrete
{
    public class EmployeeRequestManager: IEmployeeRequestsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRequestManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(EmployeeRequests entity)
        {
            if (Validation(entity))
            {

                _unitOfWork.EmployeeRequests.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        public async Task UpdateAsync(EmployeeRequests entity)
        {
            if (Validation(entity))
            {
                await _unitOfWork.EmployeeRequests.UpdateAsync(entity);
            }
        }
        public void Delete(EmployeeRequests entity)
        {
            _unitOfWork.EmployeeRequests.Delete(entity);
            _unitOfWork.Save();
        }

        public List<EmployeeRequests> GetAll()
        {
            return _unitOfWork.EmployeeRequests.GetAll();
        }

        public EmployeeRequests GetById(int id)
        {
            return _unitOfWork.EmployeeRequests.GetById(id);
        }

       
        public bool Update(EmployeeRequests entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.EmployeeRequests.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(EmployeeRequests entity)
        {
            var isValid = true;
            if (entity.EmployeeId==null)
            {
                ErrorMessage += "Employee Not Found.";
                return false;
            }
            return isValid;
        }

        public EmployeeRequests GetByEmployeeIdAndRequestId(string employeeId, int requestId)
        {
            return _unitOfWork.EmployeeRequests.GetByEmployeeIdAndRequestId(employeeId,requestId);
        }
    }
}
