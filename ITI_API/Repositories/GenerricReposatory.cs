using ITI_API.Interfaces;
using ITI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Repositories
{
    public class GenerricReposatory<TEntity>(ItiContext db) : IGenericRepository<TEntity> where TEntity : class
    {
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }
        public async Task AddAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
        }
        public async Task<TEntity> UpdateByIdAsync(int id)
        {
            var entity = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Update(entity);
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public async Task<bool> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            return true;
        }
        public async Task<bool> RemoveRangeAsync(List<TEntity> entitires)
        {
            db.Set<TEntity>().RemoveRange(entitires);
            return true;
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
