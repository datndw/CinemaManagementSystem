using CinemaManagementSystem.Application.DTOs.User;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
}