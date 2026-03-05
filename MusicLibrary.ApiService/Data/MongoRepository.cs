using MongoDB.Bson;
using MongoDB.Driver;
using MusicLibrary.ApiService.Interfaces;

namespace MusicLibrary.ApiService.Data;
public class MongoRepository<T> : IMongoRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return await _collection.Find(new BsonDocument()).ToListAsync(ct);
    }

    public async Task<T> GetByIdAsync(string id, CancellationToken ct)
    {
        return await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync(ct);
    }

    public async Task AddAsync(T entity, CancellationToken ct)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: ct);
    }

    public async Task UpdateAsync(string id, T entity, CancellationToken ct)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), entity, cancellationToken: ct);
    }

    public async Task DeleteAsync(string id, CancellationToken ct)
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id)), cancellationToken: ct);
    }
}
