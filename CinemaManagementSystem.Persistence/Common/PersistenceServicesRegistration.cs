using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Persistence.DbContexts;
using CinemaManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Common
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CinemaManagementSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CinemaManagementSystemDB"))
            );
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            return services;
        }
    }
}
