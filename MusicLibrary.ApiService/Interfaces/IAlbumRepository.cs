using MusicLibrary.ApiService.Schemas;
using MongoDB.Driver;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for the AlbumRepository, providing methods for managing Album entities.
/// </summary>
public interface IAlbumRepository : IMongoRepository<Album>
{
    // Add custom Album-specific repository methods here if needed in the future.
}
