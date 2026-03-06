using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MusicLibrary.Domain.Interfaces.Persistence;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository for managing Song entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SongRepository"/> class.
/// </remarks>
/// <param name="database">The MongoDB database instance.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class SongRepository(IMongoDatabase database, ILogger<SongRepository> logger) 
    : MongoRepository<Song>(database, "songs", logger), ISongRepository
{
}