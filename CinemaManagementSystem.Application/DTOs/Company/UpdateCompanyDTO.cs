using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Company
{
	public class UpdateCompanyDTO : BaseDTO, ICompanyDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
    }
}