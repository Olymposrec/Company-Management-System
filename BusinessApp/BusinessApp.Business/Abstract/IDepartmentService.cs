using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.Business.Abstract
{
    public interface IDepartmentService: IValidator<Department>
    {
        Department GetById(int id);
        List<Department> GetAll();
        Task<List<Department>> GetAllAsync();
        bool Create(Department entity);
        bool Update(Department entity);
        Task UpdateAsync(Department entity);
        void Delete(Department entity);
    }
}
