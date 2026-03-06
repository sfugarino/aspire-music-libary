
using MongoDB.Driver;

namespace MusicLibrary.Domain.Interfaces.Persistence;
/// <summary>
/// Generic interface for MongoDB repository operations.
/// </summary>
public interface IMongoRepository<T> where T : class
{
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> asynchronously.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>List of all entities.</returns>
    Task<List<T>> GetAllAsync(CancellationToken ct);

    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The entity ID.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<T> GetByIdAsync(string id, CancellationToken ct);

    /// <summary>
    /// Finds entities in the collection matching the given filter expression.
    /// </summary>
    /// <param name="filter">A filter expression for the query.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>List of matching entities.</returns>
    Task<List<T>> FindAsync(FilterDefinition<T> filter, CancellationToken ct);

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="ct">Cancellation token.</param>
    Task AddAsync(T entity, CancellationToken ct);

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="entity">The updated entity.</param>
    /// <param name="ct">Cancellation token.</param>
    Task UpdateAsync(string id, T entity, CancellationToken ct);

    /// <summary>
    /// Deletes an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="ct">Cancellation token.</param>
    Task DeleteAsync(string id, CancellationToken ct);
}