using CinemaManagementSystem.Application.DTOs.Rate;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Requests.Queries
{
    public class GetRatesRequest : IRequest<List<RateDTO>>
    {
    }
}