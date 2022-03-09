using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface IRequestDepartmentService : IValidator<RequestDepartment>
    {
        RequestDepartment GetById(int id);
        List<RequestDepartment> GetAll();
        bool Create(RequestDepartment entity);
        bool Update(RequestDepartment entity);
        void Delete(RequestDepartment entity);
    }
}
