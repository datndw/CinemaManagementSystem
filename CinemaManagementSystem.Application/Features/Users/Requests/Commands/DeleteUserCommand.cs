using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}