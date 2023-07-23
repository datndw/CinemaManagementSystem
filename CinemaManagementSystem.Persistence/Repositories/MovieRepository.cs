using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public MovieRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieDetailAsync(Guid id)
        {
            return await _context.Movies
                .Include(m => m.MovieActors)
                .ThenInclude(a => a.Actor)
                .Include(m => m.MovieCompanies)
                .ThenInclude(c => c.Company)
                .ThenInclude(c => c.User)
                .Include(m => m.MovieGenres)
                .ThenInclude(g => g.Genre)
                .Include(m => m.Rates)
                .ThenInclude(r => r.User)
                .Where(m => m.Id == id)
                .FirstAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenre(Guid id)
        {
            return await _context.Movies
                .Include(m => m.Rates)
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == id))
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesWithRate()
        {
            return await _context.Movies
                .Include(m => m.Rates)
                .ToListAsync();
        }
    }
}
