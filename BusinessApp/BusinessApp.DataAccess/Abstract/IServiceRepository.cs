using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IServiceRepository:IRepository<Service>
    {
        Service GetByIdWithUsers(int id);
    }
}
