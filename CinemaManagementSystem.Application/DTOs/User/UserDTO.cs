using System;
using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.User
{
	public class UserDTO : BaseDTO, IUserDTO
	{
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

