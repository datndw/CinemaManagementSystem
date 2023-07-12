using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Rate
{
	public class UpdateRateCommandResponse : BaseCommandResponse
	{
		public UpdateRateDTO UpdateRateDTO { get; set; }
    }
}