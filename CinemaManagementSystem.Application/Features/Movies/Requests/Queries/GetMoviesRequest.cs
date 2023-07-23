using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
    public class GetMoviesRequest : IRequest<List<MovieRateDTO>>
    {
    }
}