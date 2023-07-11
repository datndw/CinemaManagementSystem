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
    }
}

