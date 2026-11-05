using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.Entities;

namespace session_1.Reposatories
{
    public class GenericReposatory<T> : IGenericReposatory<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericReposatory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if(entity is null) return false;
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        =>await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);

        public async Task<bool> UpdateAsync(T entity)
        {
            var model = await GetByIdAsync(entity.Id);
            if(model is null) return false;

            _dbContext.Set<T>().Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
