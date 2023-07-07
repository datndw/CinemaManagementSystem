using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaManagementSystem.Persistence.Configurations.Entities
{
    public class MovieCompanyConfiguration : IEntityTypeConfiguration<MovieCompany>
    {
        public void Configure(EntityTypeBuilder<MovieCompany> builder)
        {
            builder.HasData(DataExtension.MovieCompanies);
        }
    }
}

