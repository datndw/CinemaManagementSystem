namespace CinemaManagementSystem.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> Exists(Guid id);
        Task<T> AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);
    }
}