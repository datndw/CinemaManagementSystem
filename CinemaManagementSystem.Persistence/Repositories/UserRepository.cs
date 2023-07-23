using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;

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
            _context.MovieUsers.Add(new MovieUser { MovieId = movieId, UserId = userId });
        }

        public void RemoveFromFavorites(Guid userId, Guid movieId)
        {
            var removingEntity = _context.MovieUsers.FirstOrDefault(mu => mu.MovieId == movieId && mu.UserId == userId);
            _context.MovieUsers.Remove(removingEntity);
        }
    }
}

