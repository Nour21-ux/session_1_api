using AutoMapper;
using session_1.DTOS.PatientDto;
using session_1.Entities;

namespace session_1.Helper
{
    public class PatientProfile:Profile
    {
       public PatientProfile()
        {
            CreateMap<Patient, GetPatientResponse>()
                .ForMember(dest => dest.PatientID,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PatientName,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PatientDateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth));
        }
    }
}
