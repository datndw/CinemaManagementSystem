using System;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Commands
{
	public class AddToFavoritesCommand : IRequest<bool>
	{
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}

