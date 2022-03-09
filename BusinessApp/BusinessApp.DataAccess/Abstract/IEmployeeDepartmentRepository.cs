using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IEmployeeDepartmentRepository:IRepository<EmployeeDepartment>
    {
        bool FindByDepartmentAndEmployeeId(int departmentId, string userId);
    }
}
