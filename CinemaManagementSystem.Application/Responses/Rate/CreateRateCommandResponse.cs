using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Rate
{
    public class CreateRateCommandResponse : BaseCommandResponse
	{
		public CreateRateDTO CreateRateDTO { get; set; }
    }
}