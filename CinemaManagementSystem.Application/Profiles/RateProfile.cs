using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class RateProfile : Profile
	{
		public RateProfile()
		{
            CreateMap<Rate, RateDTO>()
                .ReverseMap();
            CreateMap<Rate, CreateRateDTO>()
                .ReverseMap();
            CreateMap<Rate, UpdateRateDTO>()
                .ReverseMap();
            CreateMap<Rate, RateDetailDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
        }
	}
}