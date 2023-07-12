using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Actor
{
	public class UpdateActorCommandResponse : BaseCommandResponse
	{
		public UpdateActorDTO UpdateActorDTO { get; set; }
    }
}