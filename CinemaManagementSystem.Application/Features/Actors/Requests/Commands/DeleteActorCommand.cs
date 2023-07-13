using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Requests.Commands
{
    public class DeleteActorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}