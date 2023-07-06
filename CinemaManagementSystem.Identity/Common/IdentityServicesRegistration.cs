﻿using CinemaManagementSystem.Application.Contracts.Identity;
using CinemaManagementSystem.Application.Models.Identity;
using CinemaManagementSystem.Identity.DbContexts;
using CinemaManagementSystem.Identity.Models;
using CinemaManagementSystem.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Identity.Common
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<CinemaManagementSystemIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CinemaManagementSystemIdentityDB"),
                b => b.MigrationsAssembly(typeof(CinemaManagementSystemIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<CinemaManagementSystemIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))

                    };
                });

            return services;
        }
    }
}
