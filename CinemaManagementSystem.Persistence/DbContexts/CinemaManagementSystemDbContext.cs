using CinemaManagementSystem.Domain.Common;
using CinemaManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.DbContexts
{
    public class CinemaManagementSystemDbContext : DbContext
    {
        public CinemaManagementSystemDbContext(DbContextOptions<CinemaManagementSystemDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaManagementSystemDbContext).Assembly);

            modelBuilder.Entity<Rate>()
                .HasOne<Movie>(r => r.Movie)
                .WithMany(m => m.Rates)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieActors).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Actor).WithMany(e => e.MovieActors).HasForeignKey(e => e.ActorId);
            });

            modelBuilder.Entity<MovieCompany>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.CompanyId });
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieCompanies).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Company).WithMany(e => e.MovieCompanies).HasForeignKey(e => e.CompanyId);
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId });
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieGenres).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Genre).WithMany(e => e.MovieGenres).HasForeignKey(e => e.GenreId);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
