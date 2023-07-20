using System;
namespace CinemaManagementSystem.Domain.Entities
{
	public class MovieUser
	{
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

