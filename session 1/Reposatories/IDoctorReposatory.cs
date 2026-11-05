using Microsoft.EntityFrameworkCore;
using session_1.Entities;
using session_1.Results;

namespace session_1.Reposatories
{
    public interface IDoctorReposatory
    {
        Task<IEnumerable<Doctor>> GetAllAsync();


        Task<PaginatedList<Doctor>> GetAllAsync(int pageNumber, int pageSize, string? searchTerm);
        

        Task<Doctor> GetByIdAsync(int id);

         Task<Doctor> CreateAsync(Doctor doctor);


         Task<bool> UpdateAsync(Doctor doctor);


        Task<bool> DeleteAsync(int id);
        
    }
}
