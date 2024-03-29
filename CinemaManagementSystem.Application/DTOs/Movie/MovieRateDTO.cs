﻿using System;
using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Movie
{
    public class MovieRateDTO : BaseDTO, IMovieDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackDropUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int AgeRequired { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Status { get; set; }
        public double AvgRate { get; set; }
        public List<string> CompanyNames { get; set; }
    }
}

