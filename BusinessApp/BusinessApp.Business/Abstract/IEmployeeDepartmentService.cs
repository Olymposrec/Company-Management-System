using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface IEmployeeDepartmentService: IValidator<EmployeeDepartment>
    {
        EmployeeDepartment GetById(int id);
        List<EmployeeDepartment> GetAll();
        bool FindByDepartmentAndEmployeeId(int departmentId, string userId);
        bool Create(EmployeeDepartment entity);
        bool Update(EmployeeDepartment entity);
        void Delete(EmployeeDepartment entity);
    }
}
