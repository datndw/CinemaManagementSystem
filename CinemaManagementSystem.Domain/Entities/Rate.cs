using CinemaManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class Rate : BaseDomainEntity
    {
        public double Rating { get; set; }
        public string Comment { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
