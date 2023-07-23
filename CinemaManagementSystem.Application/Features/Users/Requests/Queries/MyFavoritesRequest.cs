using System;
using CinemaManagementSystem.Application.DTOs.Common;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Users.Requests.Queries
{
	public class MyFavoritesRequest : IRequest<List<FavoritesDTO>>
	{
        public Guid Id { get; set; }
    }
}

