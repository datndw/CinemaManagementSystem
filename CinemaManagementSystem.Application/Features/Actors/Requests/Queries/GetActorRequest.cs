using CinemaManagementSystem.Application.DTOs.Actor;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Requests.Queries
{
	public class GetActorRequest : IRequest<ActorDTO>
	{
        public Guid Id { get; set; }
    }
}