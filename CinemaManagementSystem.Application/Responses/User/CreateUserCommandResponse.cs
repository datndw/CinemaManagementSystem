using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.User
{
	public class CreateUserCommandResponse : BaseCommandResponse
	{
		public CreateUserDTO CreateUserDTO { get; set; }
    }
}