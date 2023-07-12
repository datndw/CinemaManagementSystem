using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Actor
{
	public class CreateActorCommandResponse : BaseCommandResponse
	{
		public CreateActorDTO CreateActorDTO { get; set; }
    }
}