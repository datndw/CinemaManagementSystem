using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Responses.Rate;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Requests.Commands
{
    public class CreateRateCommand : IRequest<CreateRateCommandResponse>
    {
        public CreateRateDTO CreateRateDTO { get; set; }
    }
}