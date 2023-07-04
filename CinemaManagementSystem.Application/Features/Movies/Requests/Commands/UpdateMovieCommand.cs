using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public MovieDTO MovieDTO { get; set; }
        public ChangeMovieImageUrlDTO ChangeMovieImageUrlDTO { get; set; }
    }
}
