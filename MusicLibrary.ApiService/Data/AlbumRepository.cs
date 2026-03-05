using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Repository for managing Album entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AlbumRepository"/> class.
/// </remarks>
/// <param name="database">The MongoDB database instance.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class AlbumRepository(IMongoDatabase database, ILogger<AlbumRepository> logger) 
    : MongoRepository<Album>(database, "albums", logger), IAlbumRepository
{
}