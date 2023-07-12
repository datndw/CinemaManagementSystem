using System;
namespace CinemaManagementSystem.Application.DTOs.Rate
{
    public class CreateRateDTO : IRateDTO
	{
        public double Rating { get; set; }
        public string? Comment { get; set; }
    }
}

