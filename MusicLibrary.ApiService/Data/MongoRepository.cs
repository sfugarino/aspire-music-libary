using MongoDB.Bson;
using MongoDB.Driver;
using MusicLibrary.ApiService.Interfaces;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Generic MongoDB repository implementation for CRUD operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public class MongoRepository<T> : IMongoRepository<T> where T : class
{

    /// <summary>
    /// The MongoDB collection for the entity type.
    /// </summary>
    protected readonly IMongoCollection<T> _collection;

    /// <summary>
    /// The logger instance for this repository.
    /// </summary>
    protected readonly ILogger<IMongoRepository<T>> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoRepository{T}"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="logger">The logger instance.</param>
    public MongoRepository(IMongoDatabase database, string collectionName, ILogger<IMongoRepository<T>> logger)
    {
        _collection = database.GetCollection<T>(collectionName);
        _logger = logger;
    }

    /// <summary>
    /// Retrieves all entities from the collection asynchronously.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>List of all entities.</returns>
    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        try
        {
            var result = await _collection.Find(new BsonDocument()).ToListAsync(ct);
            _logger.LogInformation("Retrieved all documents of type {EntityType} from collection {CollectionName}.", typeof(T).Name, _collection.CollectionNamespace.CollectionName);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all documents of type {EntityType} from collection {CollectionName}.", typeof(T).Name, _collection.CollectionNamespace.CollectionName);
            throw;
        }
    }

    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The entity ID.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public async Task<T> GetByIdAsync(string id, CancellationToken ct)
    {
        try
        {
            var result = await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync(ct);
            _logger.LogInformation("Retrieved document of type {EntityType} with ID {Id} from collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving document of type {EntityType} with ID {Id} from collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
            throw;
        }
    }

    /// <summary>
    /// Adds a new entity to the collection asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="ct">Cancellation token.</param>
    public async Task AddAsync(T entity, CancellationToken ct)
    {
        try
        {
            await _collection.InsertOneAsync(entity, cancellationToken: ct);
            _logger.LogInformation("Inserted new document of type {EntityType} into collection {CollectionName}.", typeof(T).Name, _collection.CollectionNamespace.CollectionName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting document of type {EntityType} into collection {CollectionName}.", typeof(T).Name, _collection.CollectionNamespace.CollectionName);
            throw;
        }
    }

    /// <summary>
    /// Updates an existing entity in the collection asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="entity">The updated entity.</param>
    /// <param name="ct">Cancellation token.</param>
    public async Task UpdateAsync(string id, T entity, CancellationToken ct)
    {
        try
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity, cancellationToken: ct);
            _logger.LogInformation("Updated document of type {EntityType} with ID {Id} in collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating document of type {EntityType} with ID {Id} in collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
            throw;
        }
    }

    /// <summary>
    /// Deletes an entity by its ID from the collection asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="ct">Cancellation token.</param>
    public async Task DeleteAsync(string id, CancellationToken ct)
    {
        try
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), cancellationToken: ct);
            _logger.LogInformation("Deleted document of type {EntityType} with ID {Id} from collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting document of type {EntityType} with ID {Id} from collection {CollectionName}.", typeof(T).Name, id, _collection.CollectionNamespace.CollectionName);
            throw;
        }
    }
}
