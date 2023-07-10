using System;
using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Genre
{
	public class CreateGenreCommandResponse : BaseCommandResponse
	{
        public CreateGenreDTO CreateGenreDTO { get; set; }
    }
}

