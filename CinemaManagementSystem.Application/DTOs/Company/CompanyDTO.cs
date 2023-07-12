using CinemaManagementSystem.Application.DTOs.Common;

namespace CinemaManagementSystem.Application.DTOs.Company
{
	public class CompanyDTO : BaseDTO, ICompanyDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? UserId { get; set; }
    }
}