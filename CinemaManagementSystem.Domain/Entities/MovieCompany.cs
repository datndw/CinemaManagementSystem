using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class MovieCompany
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
