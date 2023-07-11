using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Movie
{
    public class UpdateMovieCommandResponse : BaseCommandResponse
	{
		public UpdateMovieDTO UpdateMovieDTO { get; set; }
    }
}