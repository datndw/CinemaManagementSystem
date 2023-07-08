using CinemaManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class Company : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public IList<MovieCompany> MovieCompanies { get; set; }

    }
}
