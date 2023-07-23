using System;
using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.Movie;

namespace CinemaManagementSystem.Application.DTOs.Genre
{
    public class GenreDetailDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<MovieDTO> Movies { get; set; }
    }
}

