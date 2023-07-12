using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Company
{
	public class CreateCompanyCommandResponse : BaseCommandResponse
	{
		public CreateCompanyDTO CreateCompanyDTO { get; set; }

    }
}