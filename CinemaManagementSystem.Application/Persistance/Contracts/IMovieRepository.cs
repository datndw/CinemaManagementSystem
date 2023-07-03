using CinemaManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Persistance.Contracts
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    }
}
