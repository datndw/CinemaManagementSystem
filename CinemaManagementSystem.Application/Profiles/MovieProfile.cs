using AutoMapper;
using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ReverseMap();
            CreateMap<Movie, CreateMovieDTO>()
                .ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>()
                .ReverseMap();
        }
    }
}