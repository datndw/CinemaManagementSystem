using CinemaManagementSystem.Application.DTOs.Company;
using MediatR;

namespace CinemaManagementSystem.Application.Features.Companies.Requests.Queries
{
	public class GetCompaniesRequest : IRequest<List<CompanyDTO>>
	{
	}
}