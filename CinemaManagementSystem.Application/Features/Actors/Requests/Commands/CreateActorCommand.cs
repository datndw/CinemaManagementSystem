using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Responses.Actor;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Requests.Commands
{
    public class CreateActorCommand : IRequest<CreateActorCommandResponse>
    {
        public CreateActorDTO CreateActorDTO { get; set; }
    }
}