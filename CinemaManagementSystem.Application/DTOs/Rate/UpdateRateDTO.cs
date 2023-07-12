using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Rate
{
    public class UpdateRateDTO : BaseDTO, IRateDTO
    {
        public double Rating { get; set; }
        public string? Comment { get; set; }
    }
}