using CinemaManagementSystem.Application.DTOs.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Queries
{
    public class GetGenresRequest : IRequest<List<GenreDTO>>
    {
    }
}