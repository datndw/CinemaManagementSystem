using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Responses.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Commands
{
    public class UpdateGenreCommand : IRequest<UpdateGenreCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateGenreDTO UpdateGenreDTO { get; set; }
    }
}