using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        void Create(T entity);
        void Update(T entity);
        Task  UpdateAsync(T entity);
        Task  CreateAsync(T entity);
        void Delete(T entity);
    }
}
