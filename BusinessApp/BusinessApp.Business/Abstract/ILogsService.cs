using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Abstract
{
    public interface ILogsService
    {
        Log GetById(int id);
        List<Log> GetAll();
        void Create(Log entity);
        void Update(Log entity);
        void Delete(Log entity);
        void DeleteAll(List<Log> entity);
    }
}
