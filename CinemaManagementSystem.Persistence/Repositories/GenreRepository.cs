using CinemaManagementSystem.Application.Contracts.Persistence;
using CinemaManagementSystem.Domain.Entities;
using CinemaManagementSystem.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly CinemaManagementSystemDbContext _context;
        public GenreRepository(CinemaManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
