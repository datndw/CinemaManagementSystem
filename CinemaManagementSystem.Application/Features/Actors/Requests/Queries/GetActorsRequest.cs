using CinemaManagementSystem.Application.DTOs.Actor;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Actors.Requests.Queries
{
	public class GetActorsRequest : IRequest<List<ActorDTO>>
	{
	}
}