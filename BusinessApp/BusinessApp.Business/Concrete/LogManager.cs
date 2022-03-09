using BusinessApp.Business.Abstract;
using BusinessApp.DataAccess.Abstract;
using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Business.Concrete
{
    public class LogManager : ILogsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LogManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Log entity)
        {
            _unitOfWork.Logs.Create(entity);
        }

        public void Delete(Log entity)
        {
            _unitOfWork.Logs.Delete(entity);
        }

        public void DeleteAll(List<Log> entity)
        {
            _unitOfWork.Logs.DeleteAll(entity);
        }

        public List<Log> GetAll()
        {
            return _unitOfWork.Logs.GetAll();
        }

        public Log GetById(int id)
        {
            return _unitOfWork.Logs.GetById(id);
        }

        public void Update(Log entity)
        {
            _unitOfWork.Logs.Update(entity);
        }
    }
}
