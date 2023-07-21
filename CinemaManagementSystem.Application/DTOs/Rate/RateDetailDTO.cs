using System;
using CinemaManagementSystem.Application.DTOs.Common;
using CinemaManagementSystem.Application.DTOs.User;

namespace CinemaManagementSystem.Application.DTOs.Rate
{
	public class RateDetailDTO : BaseDTO, IRateDTO
	{
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public UserDTO User { get; set; }
    }
}

