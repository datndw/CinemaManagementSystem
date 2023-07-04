using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
    public class GetMovieRequest : IRequest<MovieDTO>
    {
        public Guid Id { get; set; }
    }
}
