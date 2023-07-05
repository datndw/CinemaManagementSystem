using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public MovieRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task ChangeImageUrl(Movie movie, string imageUrl)
        {
            movie.ImageUrl = imageUrl;
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
