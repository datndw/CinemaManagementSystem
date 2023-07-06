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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = GlobalGUIDProvider.Request(0),
                UserId = GlobalGUIDProvider.Request(3)
            },
            new IdentityUserRole<Guid>
            {
                RoleId = GlobalGUIDProvider.Request(1),
                UserId = GlobalGUIDProvider.Request(4)
            },
            new IdentityUserRole<Guid>
            {
                RoleId = GlobalGUIDProvider.Request(2),
                UserId = GlobalGUIDProvider.Request(5)
            }
            );
        }
    }
}
