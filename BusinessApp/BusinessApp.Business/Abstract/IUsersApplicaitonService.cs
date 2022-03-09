using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Abstract
{
    public interface IUsersApplicaitonService : IValidator<UsersApplication>
    {
        UsersApplication GetById(int id);
        Task<UsersApplication> GetByIdAsync(int id);
        List<UsersApplication> GetAll();
        bool Create(UsersApplication entity);
        bool Update(UsersApplication entity);
        Task UpdateAsync(UsersApplication entity);
        void Delete(UsersApplication entity);
        UsersApplication GetByStringId(string applicationId);
    }
}
