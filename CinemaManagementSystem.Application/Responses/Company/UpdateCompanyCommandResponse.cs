using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Company
{
    public class UpdateCompanyCommandResponse : BaseCommandResponse
	{
		public UpdateCompanyDTO UpdateCompanyDTO { get; set; }

    }
}