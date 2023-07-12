using CinemaManagementSystem.Application.DTOs.Company;
using CinemaManagementSystem.Application.Responses.Common;

namespace CinemaManagementSystem.Application.Responses.Company
{
    public class UpdateComanyCommandResponse : BaseCommandResponse
	{
		public UpdateCompanyDTO UpdateCompanyDTO { get; set; }

    }
}