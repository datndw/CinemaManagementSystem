using CinemaManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Contracts.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task ChangeImageUrl(Movie movie, string imageUrl);
    }
}
