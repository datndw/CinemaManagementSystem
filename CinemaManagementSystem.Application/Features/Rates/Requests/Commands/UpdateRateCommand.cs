using CinemaManagementSystem.Application.DTOs.Rate;
using CinemaManagementSystem.Application.Responses.Rate;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Requests.Commands
{
    public class UpdateRateCommand : IRequest<UpdateRateCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateRateDTO UpdateRateDTO { get; set; }
    }
}