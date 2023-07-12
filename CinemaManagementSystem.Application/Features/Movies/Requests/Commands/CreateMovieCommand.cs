using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Responses.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<CreateMovieCommandResponse>
    {
        public CreateMovieDTO CreateMovieDTO { get; set; }
    }
}