using System;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Responses.Genre;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Genres.Requests.Commands
{
	public class CreateGenreCommand : IRequest<CreateGenreCommandResponse>
	{
		public CreateGenreDTO CreateGenreDTO { get; set; }
	}
}

