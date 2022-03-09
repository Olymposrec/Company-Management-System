using BusinessApp.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity>
    where TEntity :class
    {
        protected readonly DbContext context;
        public EfCoreGenericRepository(DbContext ctx)
        {
            context = ctx;
        }
        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {   
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task CreateAsync(TEntity entity)
        {            
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

    }
}
