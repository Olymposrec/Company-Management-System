using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface ICompanyService : IValidator<Entity.Company>
    {
        Company GetById(int id);
        List<Company> GetAll();
        bool Create(Company entity);
        bool Update(Company entity);
        void Delete(Company entity);
        Company GetByIdWithUsers(int id);
        int GetIdWithName(string firmName);
    }
}
