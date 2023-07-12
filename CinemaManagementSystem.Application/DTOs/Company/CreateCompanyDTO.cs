﻿namespace CinemaManagementSystem.Application.DTOs.Company
{
	public class CreateCompanyDTO : ICompanyDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? UserId { get; set; }
    }
}