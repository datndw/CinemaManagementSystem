using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Requests.Commands
{
    public class DeleteCompanyCommand : IRequest<bool>
	{
        public Guid Id { get; set; }
    }
}

