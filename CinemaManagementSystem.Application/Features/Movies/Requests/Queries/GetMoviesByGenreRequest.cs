using System;
using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
	public class GetMoviesByGenreRequest : IRequest<List<MovieRateDTO>>
	{
        public Guid Id { get; set; }
    }
}

