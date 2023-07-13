using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Responses.Company;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Requests.Commands
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateCompanyDTO UpdateCompanyDTO;

    }
}