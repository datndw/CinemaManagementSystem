using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public RateRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}