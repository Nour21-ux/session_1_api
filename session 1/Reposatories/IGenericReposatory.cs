using session_1.Entities;

namespace session_1.Reposatories
{
    public interface IGenericReposatory<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T  entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}
