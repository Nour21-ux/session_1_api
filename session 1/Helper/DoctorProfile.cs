using AutoMapper;
using session_1.DTOS.DoctorDto;
using session_1.Entities;

namespace session_1.Helper
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorResponc>()
                .ForMember(dest => dest.DoctorId,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DoctorName,
                opt => opt.MapFrom(src => src.Name));
        }
    }
}
