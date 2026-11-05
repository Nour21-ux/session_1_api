using session_1.DTOS.DoctorDto;
using session_1.Entities;
using session_1.Results;

namespace session_1.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();


        


        Task<GenirecResult<DoctorResponc>> GetByIdAsync(int id);

        Task<Doctor> CreateAsync(Doctor entity);


        Task<bool> UpdateAsync(Doctor entity);


        Task<bool> DeleteAsync(int id);
    }
}
