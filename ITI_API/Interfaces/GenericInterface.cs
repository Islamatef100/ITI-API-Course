using ITI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity?> UpdateByIdAsync(int id);
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> RemoveRangeAsync(List<TEntity> entities);
        Task SaveAsync();
    }
}
