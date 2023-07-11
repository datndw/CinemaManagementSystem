using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public CompanyRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

