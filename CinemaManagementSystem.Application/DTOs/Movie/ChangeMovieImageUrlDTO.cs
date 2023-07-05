﻿using CinemaManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.DTOs.Movie
{
    public class ChangeMovieImageUrlDTO : BaseDTO
    {
        public string ImageUrl { get; set; }
    }
}