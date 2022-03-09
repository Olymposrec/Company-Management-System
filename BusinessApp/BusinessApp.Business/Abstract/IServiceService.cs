using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Abstract
{
    public interface IServiceService:IValidator<Service>
    {
        Service GetById(int id);
        List<Service> GetAll();
        Task<List<Service>> GetAllAsync();
        bool Create(Service entity);
        bool Update(Service entity);
        Task UpdateAsync(Service entity);
        void Delete(Service entity);
        Service GetByIdWithUsers(int id);
    }
}
