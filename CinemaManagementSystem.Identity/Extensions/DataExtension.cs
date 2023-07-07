using CinemaManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaManagementSystem.Identity.Extensions
{
    public static class DataExtension
	{
        static PasswordHasher<ApplicationUser> Hasher = new PasswordHasher<ApplicationUser>();
        public static List<IdentityRole<Guid>> Roles = new List<IdentityRole<Guid>>
        {
            new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "Publisher",
                    NormalizedName = "PUBLISHER"
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                }
        };

        public static List<IdentityUser<Guid>> Users = new List<IdentityUser<Guid>>
        {
            new ApplicationUser
                 {
                     Id = Guid.NewGuid(),
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "admin",
                     NormalizedUserName = "ADMIN",
                     PasswordHash = Hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = Guid.NewGuid(),
                     Email = "publisher@localhost.com",
                     NormalizedEmail = "PUBLISHER@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "publisher",
                     NormalizedUserName = "PUBLISHER",
                     PasswordHash = Hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = Guid.NewGuid(),
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = "user",
                     NormalizedUserName = "USER",
                     PasswordHash = Hasher.HashPassword(null, "P@ssw000000rd"),
                     EmailConfirmed = true
                 }
        };

        public static List<IdentityUserRole<Guid>> UserRoles = new List<IdentityUserRole<Guid>>
        {
            new IdentityUserRole<Guid>
            {
                RoleId = Roles.ElementAt(0).Id,
                UserId = Users.ElementAt(0).Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Roles.ElementAt(1).Id,
                UserId = Users.ElementAt(1).Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Roles.ElementAt(2).Id,
                UserId = Users.ElementAt(2).Id
            }
        };
    }
}

