using System;
using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Genre
{
    public class UpdateGenreDTO : BaseDTO, IGenreDTO
    {
        public string Name { get; set; }
    }
}

