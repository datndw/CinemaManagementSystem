using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class CompanyProfile : Profile
	{
		public CompanyProfile()
		{
            CreateMap<Company, CompanyDTO>()
                .ReverseMap();
            CreateMap<Company, CreateCompanyDTO>()
                .ReverseMap();
            CreateMap<Company, UpdateCompanyDTO>()
                .ReverseMap();
        }
	}
}