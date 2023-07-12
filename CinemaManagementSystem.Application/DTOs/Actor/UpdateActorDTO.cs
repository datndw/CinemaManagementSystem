using System;
using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Actor
{
	public class UpdateActorDTO : BaseDTO, IActorDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
    }
}

