using System;
using CinemaManagementSystem.Domain.Entities;

namespace CinemaManagementSystem.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void AddToFavorites(Guid userId, Guid movieId);
    }
}

