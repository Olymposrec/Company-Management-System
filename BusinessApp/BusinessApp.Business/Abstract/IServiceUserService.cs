using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface IServiceUserService:IValidator<ServiceUser>
    {
        ServiceUser GetById(int id);
        List<ServiceUser> GetAll();
        bool Create(ServiceUser entity);
        bool Update(ServiceUser entity);
        void Delete(ServiceUser entity);
    }
}
