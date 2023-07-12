using System;
namespace CinemaManagementSystem.Application.DTOs.Rate
{
	public interface IRateDTO
	{
        public double Rating { get; set; }
        public string? Comment { get; set; }
    }
}

