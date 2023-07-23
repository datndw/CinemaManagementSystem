using System;
namespace CinemaManagementSystem.Application.DTOs.Common
{
	public class RemoveFavoritesDTO
	{
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}

