using System;
using CinemaManagementSystem.Application.DTOs.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Queries
{
    public class GetGenresDetailRequest : IRequest<List<GenreDetailDTO>>
    {
    }
}

