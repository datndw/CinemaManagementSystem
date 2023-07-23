using System;
using CinemaManagementSystem.Application.DTOs.Movie;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Movies.Requests.Queries
{
    public class SearchMoviesRequest : IRequest<List<MovieDetailDTO>>
    {
        public string Keyword { get; set; }
    }
}

