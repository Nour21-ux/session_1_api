using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.DTOS.DoctorDto;
using session_1.DTOS.PatientDto;
using session_1.Entities;
using session_1.Reposatories;
using session_1.Results;
using session_1.Services;

namespace session_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController (IDoctorService service,ILogger<DoctorsController> logger,IMapper mapper): ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll(int pageNumber, int pageSize,string? searchTerm)
        //{
        //    List<Doctor> Doctors;
        //    var totalCount = 0;
        //    if(searchTerm is not null)
        //    {
        //        Doctors= await dbContext.Doctors.Where(d=>d.Name.Contains(searchTerm))
        //                                 .Skip((pageNumber-1)*pageSize)
        //                                  .Take(pageSize)
        //                                  .ToListAsync();
        //        totalCount = await dbContext.Doctors.CountAsync(d => d.Name.Contains(searchTerm));

        //    }
        //    else
        //    {
        //        Doctors = await dbContext.Doctors
        //                                 .Skip((pageNumber - 1) * pageSize)
        //                                  .Take(pageSize)
        //                                  .ToListAsync();
        //        totalCount = await dbContext.Doctors.CountAsync();
        //    }
        //    logger.LogInformation("get all Doctors Names", Doctors);
        //    var doctorsResponc = mapper.Map<List<DoctorResponc>>(Doctors);
        //    var paginatedList = new PaginatedList<DoctorResponc>
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalRecords = totalCount,
        //        Data = doctorsResponc,
        //        TotalPage = (int)Math.Ceiling(totalCount /(double) pageSize),
        //    };
        //    var result = GenirecResult<PaginatedList<DoctorResponc>>.Sucsess(paginatedList);
        //    return Ok(result);

        //}



        //[HttpGet("GEtAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var entities = await reposatory.GetAllAsync();
        //    var response = mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResponc>>(entities);
        //    var result = GenirecResult<IEnumerable<DoctorResponc>>.Sucsess(response);
        //    return result.IsSucsess ? Ok(result) : BadRequest(result);
        //}

        //[HttpGet("GETWithCriatiria")]
        //public async Task<IActionResult> GetAllWithPagination(int pageNumber,int pageSize,string? searchTerm)
        //{
        //    var DoctorsPaginatedList=await reposatory.GetAllAsync(pageNumber, pageSize, searchTerm);
        //    var response=MapFromEntitysTODto(DoctorsPaginatedList);
        //    var result = GenirecResult<PaginatedList<DoctorResponc>>.Sucsess(response);
        //    return Ok(result);
        //}
        //private PaginatedList<DoctorResponc> MapFromEntitysTODto(PaginatedList<Doctor>?list)
        //{
        //    var DoctorsResponse = mapper.Map<IEnumerable<Doctor>?, IEnumerable<DoctorResponc>>(list.Data);
        //    return new PaginatedList<DoctorResponc>
        //    {
        //        Data = DoctorsResponse,
        //        PageNumber = list.PageNumber,
        //        PageSize = list.PageSize,
        //        TotalRecords = list.TotalRecords,
        //        TotalPage = list.TotalPage,
        //    };
        //}

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result= await service.GetByIdAsync(id);
            return result.IsSucsess ? Ok(result) : NotFound(result);
        }
    }
}
