using MediatR;

namespace CinemaManagementSystem.Application.Features.Rates.Requests.Commands
{
    public class DeleteRateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}