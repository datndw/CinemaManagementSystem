using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Resposes.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
    {
        public MovieDTO MovieDTO { get; set; }
        public CreateMovieDTO CreateMovieDTO { get; set; }
    }
}
