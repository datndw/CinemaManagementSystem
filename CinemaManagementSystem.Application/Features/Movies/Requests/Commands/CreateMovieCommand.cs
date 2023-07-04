﻿using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<Guid>
    {
        public MovieDTO MovieDTO { get; set; }
    }
}
