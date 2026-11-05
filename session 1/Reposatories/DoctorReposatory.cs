using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.DTOS.DoctorDto;
using session_1.Entities;
using session_1.Results;

namespace session_1.Reposatories
{
    public class DoctorReposatory:IDoctorReposatory
    {
        private readonly ApplicationDbContext _dbContext;

        public DoctorReposatory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
            =>await _dbContext.Doctors.ToListAsync();

        public async Task<PaginatedList<Doctor>> GetAllAsync(int pageNumber, int pageSize,string? searchTerm)
        {
            List<Doctor> Doctors;
            var totalCount = 0;
            if (searchTerm is not null)
            {
                Doctors = await _dbContext.Doctors.Where(d => d.Name.Contains(searchTerm))
                                         .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
                totalCount = await _dbContext.Doctors.CountAsync(d => d.Name.Contains(searchTerm));

            }
            else
            {
                Doctors = await _dbContext.Doctors
                                         .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();
                totalCount = await _dbContext.Doctors.CountAsync();
            }
            var paginatedList = new PaginatedList<Doctor>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalCount,
                Data = Doctors,
                TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize),
            };
            return paginatedList;
        }

        public async Task<Doctor> GetByIdAsync(int id) 
            =>await _dbContext.Doctors.FindAsync(id);

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<bool> UpdateAsync(Doctor doctor)
        {
            var entity=await GetByIdAsync(doctor.Id);
            if(entity == null) 
                return false;
            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity=await GetByIdAsync(id);
            if(entity == null) return false;
            _dbContext.Doctors.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
