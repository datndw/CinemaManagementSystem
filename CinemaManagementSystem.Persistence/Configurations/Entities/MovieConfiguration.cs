using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(DataExtension.Movies);
        }
    }
}
