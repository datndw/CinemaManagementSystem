using System;
namespace CinemaManagementSystem.Application.DTOs.Common
{
	public class AddFavoritesDTO
	{
		public Guid MovieId { get; set; }
		public Guid UserId { get; set; }
	}
}

