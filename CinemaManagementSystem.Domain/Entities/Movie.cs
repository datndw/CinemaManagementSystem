using CinemaManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Domain.Entities
{
    public class Movie : BaseDomainEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackDropUrl { get; set; }
        public int AgeRequired { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public IList<MovieActor> MovieActors { get; set; }
        public IList<MovieGenre> MovieGenres { get; set; }
        public IList<MovieCompany> MovieCompanies { get; set; }

    }
}
