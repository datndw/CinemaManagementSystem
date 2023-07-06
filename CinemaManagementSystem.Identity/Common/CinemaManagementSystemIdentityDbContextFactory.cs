using CinemaManagementSystem.Identity.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Identity.Common
{
    public class CinemaManagementSystemIdentityDbContextFactory : IDesignTimeDbContextFactory<CinemaManagementSystemIdentityDbContext>
    {
        public CinemaManagementSystemIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CinemaManagementSystemIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("CinemaManagementSystemIdentityDB");
            builder.UseSqlServer(connectionString);

            return new CinemaManagementSystemIdentityDbContext(builder.Options);
        }
    }
}
