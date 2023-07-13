using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Responses.User;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public CreateUserDTO CreateUserDTO { get; set; }
    }
}