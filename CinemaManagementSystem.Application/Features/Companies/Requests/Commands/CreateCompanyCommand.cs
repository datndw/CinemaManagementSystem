using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Responses.Company;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Requests.Commands
{
    public class CreateCompanyCommand : IRequest<CreateCompanyCommandResponse>
	{
		public CreateCompanyDTO CreateCompanyDTO { get; set; }
    }
}