using CinemaManagementSystem.Application.DTOs.Rate;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Requests.Queries
{
    public class GetRateRequest : IRequest<RateDTO>
    {
        public Guid Id { get; set; }
    }
}