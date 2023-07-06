using CinemaManagementSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CinemaManagementSystem.Persistence.Common
{
    public class CinemaManagementSystemDbContextFactory : IDesignTimeDbContextFactory<CinemaManagementSystemDbContext>
    {
        public CinemaManagementSystemDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CinemaManagementSystemDbContext>();
            var connectionString = configuration.GetConnectionString("CinemaManagementSystemDB");
            builder.UseSqlServer(connectionString);

            return new CinemaManagementSystemDbContext(builder.Options);
        }
    }
}
