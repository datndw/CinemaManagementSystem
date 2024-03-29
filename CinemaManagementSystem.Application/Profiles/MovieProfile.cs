﻿using AutoMapper;
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
            CreateMap<Movie, MovieRateDTO>()
                .ForMember(dest => dest.AvgRate, opt => opt.MapFrom(src => Average(src.Rates)))
                .ForMember(dest => dest.CompanyNames, opt => opt.MapFrom(src => src.MovieCompanies.Select(mc => mc.Company.Name).ToList()))
                .ReverseMap();
            CreateMap<Movie, CreateMovieDTO>()
                .ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>()
                .ReverseMap();
            CreateMap<Movie, MovieDetailDTO>()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(a => a.Actor)))
                .ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.MovieCompanies.Select(c => c.Company)))
                .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rates))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.MovieGenres.Select(g => g.Genre)))
                .ReverseMap();
        }

        private double Average(ICollection<Rate>? rates)
        {
            if (rates == null || rates.Count == 0)
                return 0;

            double sum = rates.Sum(r => r.Rating);
            return sum / rates.Count;
        }
    }
}