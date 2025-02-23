namespace PrecisionFarming.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync(params string[] includes);
        Task<T?> GetAsync(Guid id, params string[] includes);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
