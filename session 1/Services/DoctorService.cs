using AutoMapper;
using session_1.DTOS.DoctorDto;
using session_1.Entities;
using session_1.Reposatories;
using session_1.Results;

namespace session_1.Services
{
    public class DoctorService(IGenericReposatory<Doctor> reposatory,IMapper mapper) : IDoctorService
    {
        public async Task<Doctor> CreateAsync(Doctor entity)
        =>await reposatory.CreateAsync(entity);

        public async Task<bool> DeleteAsync(int id)
        =>await reposatory.DeleteAsync(id);

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        =>await reposatory.GetAllAsync();

        public async Task<GenirecResult<DoctorResponc>> GetByIdAsync(int id)
        {
            var entity = await reposatory.GetByIdAsync(id);
            GenirecResult<DoctorResponc>? result;
            if(entity is null)
            {
                result = GenirecResult<DoctorResponc>.Failure($"Doctor with id :{id} not found");
            }
            else
            {
                var response= mapper.Map<DoctorResponc>(entity);
                result=GenirecResult<DoctorResponc>.Sucsess(response);
            }
            return result;

        }

        public async Task<bool> UpdateAsync(Doctor entity)
        =>await reposatory.UpdateAsync(entity);
    }
}
