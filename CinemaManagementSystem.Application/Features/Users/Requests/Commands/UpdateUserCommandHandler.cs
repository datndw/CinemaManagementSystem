using CinemaManagementSystem.Application.DTOs.User;
using CinemaManagementSystem.Application.Responses.User;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Commands
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateUserDTO UpdateUserDTO { get; set; }
    }
}