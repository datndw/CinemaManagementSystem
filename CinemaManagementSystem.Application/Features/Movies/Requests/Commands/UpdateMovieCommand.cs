using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Responses.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Commands
{
    public class UpdateMovieCommand : IRequest<UpdateMovieCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateMovieDTO UpdateMovieDTO { get; set; }
    }
}