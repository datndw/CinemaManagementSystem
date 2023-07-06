using CinemaManagementSystem.Identity.Extensions;
using CinemaManagementSystem.Identity.Models;
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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = GlobalGUIDProvider.Request(3),
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "admin",
                     NormalizedUserName = "ADMIN",
                     PasswordHash = hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = GlobalGUIDProvider.Request(4),
                     Email = "publisher@localhost.com",
                     NormalizedEmail = "PUBLISHER@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "publisher",
                     NormalizedUserName = "PUBLISHER",
                     PasswordHash = hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = GlobalGUIDProvider.Request(5),
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "user",
                     NormalizedUserName = "USER",
                     PasswordHash = hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
