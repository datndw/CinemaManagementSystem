using System;
using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.DTOs.Rate;

namespace CinemaManagementSystem.Application.DTOs.Movie
{
    public class MovieDetailDTO : BaseDTO, IMovieDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackDropUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int AgeRequired { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Status { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<ActorDTO> Actors { get; set; }
        public List<CompanyDTO> Companies { get; set; }
        public List<RateDetailDTO> Rates { get; set; }
    }
}

