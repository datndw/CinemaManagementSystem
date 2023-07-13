using CinemaManagementSystem.Application.DTOs.Company;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Requests.Queries
{
    public class GetCompanyRequest : IRequest<CompanyDTO>
	{
		public Guid Id { get; set; }
	}
}