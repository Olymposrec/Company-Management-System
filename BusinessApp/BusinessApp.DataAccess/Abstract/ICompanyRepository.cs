using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Abstract
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetByIdWithUsers(int id);
        int GetIdWithName(string firmName);
    }
}
