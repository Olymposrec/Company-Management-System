using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IUsersApplicationRepository:IRepository<UsersApplication>
    {
        UsersApplication GetByStringId(string id);
    }
}
