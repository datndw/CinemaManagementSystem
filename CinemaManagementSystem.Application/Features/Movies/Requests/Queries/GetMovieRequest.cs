using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
    public class GetMovieRequest : IRequest<MovieDTO>
    {
        public Guid Id { get; set; }
    }
}
