using System;
using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.User
{
	public class UpdateUserDTO : BaseDTO, IUserDTO
	{
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

