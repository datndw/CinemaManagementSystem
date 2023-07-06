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
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasData(
                new Rate
                {
                    Id = Guid.NewGuid(),
                    Rating = 9.5,
                    Comment = "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi",
                    CreatedBy = "Administrator",
                    LastModifiedBy = "Administrator"
                }
            );
        }
    }
}
