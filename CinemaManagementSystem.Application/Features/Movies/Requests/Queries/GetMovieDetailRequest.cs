using System;
using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
    public class GetMovieDetailRequest : IRequest<MovieDetailDTO>
    {
        public Guid Id { get; set; }
    }
}

