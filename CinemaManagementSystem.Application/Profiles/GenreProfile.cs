using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class GenreProfile : Profile
	{
		public GenreProfile()
		{
            CreateMap<Genre, GenreDTO>()
                .ReverseMap();
            CreateMap<Genre, CreateGenreDTO>()
                .ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>()
                .ReverseMap();
        }
	}
}