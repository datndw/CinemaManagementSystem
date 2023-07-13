using CinemaManagementSystem.Application.DTOs.User;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Queries
{
    public class GetUsersRequest : IRequest<List<UserDTO>>
    {
    }
}