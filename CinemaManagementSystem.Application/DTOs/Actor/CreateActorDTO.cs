using System;
namespace CinemaManagementSystem.Application.DTOs.Actor
{
	public class CreateActorDTO : IActorDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
    }
}

