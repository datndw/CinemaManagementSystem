using System;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Commands
{
    public class RemoveFromFavoritesCommand : IRequest<bool>
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}

