using CinemaManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Fast & Furious X",
                    Description = "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.",
                    ImageUrl = "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg",
                    BackDropUrl = "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg",
                    AgeRequired = 8,
                    ReleaseDate = DateTime.Now,
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                }
            );
        }
    }
}
