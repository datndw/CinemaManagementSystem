using System;
using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public UserRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddToFavorites(Guid userId, Guid movieId)
        {
            var existing = _context.MovieUsers.FirstOrDefault(mu => mu.MovieId == movieId && mu.UserId == userId);

            if (existing == null)
            {
                var mu = new MovieUser
                {
                    MovieId = movieId,
                    UserId = userId
                };

                _context.MovieUsers.Add(mu);
            }
            else
            {
            }
        }

        public async Task<List<Movie>> FavoritesAsync(Guid userId)
        {
            return await _context.MovieUsers
                .Include(mu => mu.Movie)
                .Where(mu => mu.UserId == userId)
                .Select(mu => mu.Movie)
                .ToListAsync();
        }

        public async Task<List<User>> GetDetailsAsync()
        {
            return await _context.Users
                .Include(u => u.Company)
                .ToListAsync();
        }

        public async Task<User> GetDetailAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Company)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }

        public void RemoveFromFavorites(Guid userId, Guid movieId)
        {
            var removingEntity = _context.MovieUsers.FirstOrDefault(mu => mu.MovieId == movieId && mu.UserId == userId);
            _context.MovieUsers.Remove(removingEntity);
        }
    }
}

