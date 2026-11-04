using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.DTOS.PatientDto;
using session_1.Entities;

namespace session_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllPatients()
        {
            var patients=await _dbContext.Patients.ToListAsync();
            return Ok(patients);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient=await _dbContext.Patients.FirstOrDefaultAsync(p=>p.Id==id);
            if(patient==null)
                return NotFound($"Patient with id : {id} not found!");
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatPatientRequest request)
        {
            var patient = new Patient
            {
                Name = request.Name,
                DateOfBirth = DateTime.Now.Date,
            };
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientRequest request)
        {
            var patient = await _dbContext.Patients.FindAsync(request.Id);
            if (patient == null)
                return NotFound($"Patient with id : {request.Id} not found!");
            patient.Name = request.Name;
            patient.DateOfBirth = request.DateOfBirth;
            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            var patient=await _dbContext.Patients.FindAsync(id);
            if (patient is null)
                return NotFound($"\"Patient with id : {id} not found!");
            patient.IsDeleted= true;
            _dbContext.Patients.Update(patient);
            //_dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
