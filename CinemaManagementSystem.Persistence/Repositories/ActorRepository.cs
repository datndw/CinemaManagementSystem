using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public ActorRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

