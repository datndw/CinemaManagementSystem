using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Commands
{
    public class DeleteGenreCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}