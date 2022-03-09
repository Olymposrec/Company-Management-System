using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreEmployeeDepartmentRepository: EfCoreGenericRepository<EmployeeDepartment>,IEmployeeDepartmentRepository
    {
        public EfCoreEmployeeDepartmentRepository(BusinessAppContext context) : base(context)
        {

        }
        private BusinessAppContext BusinessAppContext
        {
            get { return context as BusinessAppContext; }
        }

        public bool FindByDepartmentAndEmployeeId(int departmentId, string userId)
        {
            return BusinessAppContext.EmployeeDepartments.Any(c => c.EmployeeId == userId && c.DepartmentId == departmentId);
        }
    }
}
