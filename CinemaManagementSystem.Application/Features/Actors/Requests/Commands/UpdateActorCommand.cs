using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Responses.Actor;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Requests.Commands
{
    public class UpdateActorCommand : IRequest<UpdateActorCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateActorDTO UpdateActorDTO { get; set; }
    }
}