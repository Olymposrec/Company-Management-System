using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Abstract
{
    public interface ILogsRepository: IRepository<Log>
    {
        void DeleteAll(List<Log> entity);
    }
}
