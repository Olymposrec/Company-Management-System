using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Abstract
{
    public interface IEmployeeRequestsService : IValidator<EmployeeRequests>
    {
        EmployeeRequests GetById(int id);
        EmployeeRequests GetByEmployeeIdAndRequestId(string employeeId, int requestId);
        List<EmployeeRequests> GetAll();
        bool Create(EmployeeRequests entity);
        bool Update(EmployeeRequests entity); 
        Task UpdateAsync(EmployeeRequests entity);
        void Delete(EmployeeRequests entity);
    }
}
