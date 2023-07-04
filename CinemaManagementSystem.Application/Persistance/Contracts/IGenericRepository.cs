using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> Exists(Guid id);
        Task<T> AddAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task<bool> DeleteAsync (Guid id);
    }
}
