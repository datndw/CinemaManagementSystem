using CinemaManagementSystem.Application.DTOs.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Queries
{
    public class GetGenreRequest : IRequest<GenreDTO>
    {
        public Guid Id { get; set; }
    }
}