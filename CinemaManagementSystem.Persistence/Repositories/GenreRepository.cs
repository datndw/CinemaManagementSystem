using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public GenreRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenresDetailAsync()
        {
            return await _context.Genres
                .Include(m => m.MovieGenres)
                .ThenInclude(g => g.Movie)
                .ToListAsync();
        }
    }
}
