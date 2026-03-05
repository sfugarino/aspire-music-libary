
namespace MusicLibrary.ApiService.Interfaces;
public interface IMongoRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(CancellationToken ct);
    Task<T> GetByIdAsync(string id, CancellationToken ct);
    Task AddAsync(T entity, CancellationToken ct);
    Task UpdateAsync(string id, T entity, CancellationToken ct);
    Task DeleteAsync(string id, CancellationToken ct);
}