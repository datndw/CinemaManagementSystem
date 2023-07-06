using CinemaManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class Actor : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public IList<MovieActor> MovieActors { get; set; }

    }
}
