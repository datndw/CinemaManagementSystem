using System;
using CinemaManagementSystem.Application.DTOs.Movie;

namespace CinemaManagementSystem.Application.DTOs.User
{
	public class CreateUserDTO : IUserDTO
	{
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

