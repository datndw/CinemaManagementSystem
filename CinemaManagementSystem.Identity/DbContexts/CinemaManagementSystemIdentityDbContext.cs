using CinemaManagementSystem.Identity.Configurations;
using CinemaManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Identity.DbContexts
{
    public class CinemaManagementSystemIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>,Guid>
    {
        public CinemaManagementSystemIdentityDbContext(DbContextOptions<CinemaManagementSystemIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
