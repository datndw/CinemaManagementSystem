using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.User
{
    public class UpdateUserCommandResponse : BaseCommandResponse
	{
		public UpdateUserDTO UpdateUserDTO { get; set; }
    }
}