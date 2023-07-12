using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Genre
{
    public class UpdateGenreCommandResponse : BaseCommandResponse
    {
        public UpdateGenreDTO UpdateGenreDTO { get; set; }
    }
}