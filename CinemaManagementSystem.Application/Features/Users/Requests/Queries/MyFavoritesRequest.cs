using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Queries
{
    public class MyFavoritesRequest : IRequest<List<MovieDTO>>
	{
        public Guid Id { get; set; }
    }
}

