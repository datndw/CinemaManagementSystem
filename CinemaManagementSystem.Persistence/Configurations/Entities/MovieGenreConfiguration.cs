using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasData(DataExtension.MovieGenres);
        }
    }
}

