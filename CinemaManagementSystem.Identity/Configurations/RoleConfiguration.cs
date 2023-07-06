using CinemaManagementSystem.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>
                {
                    Id = GlobalGUIDProvider.Request(0),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole<Guid>
                {
                    Id = GlobalGUIDProvider.Request(1),
                    Name = "Publisher",
                    NormalizedName = "PUBLISHER"
                },
                new IdentityRole<Guid>
                {
                    Id = GlobalGUIDProvider.Request(2),
                    Name = "User",
                    NormalizedName = "USER"
                }
                
            );
        }
    }
}
