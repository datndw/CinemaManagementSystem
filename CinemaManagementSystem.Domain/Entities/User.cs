using System;
using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.Entities
{
	public class User : BaseDomainEntity
	{
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Rate>? Rates { get; set; }
        public Company? Company { get; set; }
        public IList<MovieUser> MovieUsers { get; set; }
    }
}

