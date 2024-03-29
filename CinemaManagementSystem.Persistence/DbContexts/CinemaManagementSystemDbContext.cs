﻿using CinemaManagementSystem.Domain.Common;
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
        const string SYSTEM_NAME = "System";
        public CinemaManagementSystemDbContext(DbContextOptions<CinemaManagementSystemDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaManagementSystemDbContext).Assembly);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.HasOne<Movie>(r => r.Movie)
                .WithMany(m => m.Rates)
                .HasForeignKey(r => r.MovieId);
                entity.HasOne<User>(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.AgeRequired)
                .IsRequired();
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
                entity.HasOne(e => e.User)
                .WithOne(e => e.Company)
                .HasForeignKey<User>(e => e.CompanyId)
                .IsRequired(false);
            });

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

            modelBuilder.Entity<MovieUser>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.UserId });
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieUsers).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.User).WithMany(e => e.MovieUsers).HasForeignKey(e => e.UserId);
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = SYSTEM_NAME;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = SYSTEM_NAME;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCompany> MovieCompanies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieUser> MovieUsers { get; set; }

    }
}
