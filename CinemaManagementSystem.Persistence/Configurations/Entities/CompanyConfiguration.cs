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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "Lucasfilm Ltd.",
                    Description = "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.",
                    ImageUrl = "/o86DbpburjxrqAzEDhXZcyE8pDb.png",
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                }
            );
        }
    }
}
