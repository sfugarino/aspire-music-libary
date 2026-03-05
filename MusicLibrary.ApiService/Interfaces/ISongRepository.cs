using MusicLibrary.ApiService.Schemas;
using MongoDB.Driver;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for the SongRepository, providing methods for managing Song entities.
/// </summary>
public interface ISongRepository : IMongoRepository<Song>
{
    // Add custom Song-specific repository methods here if needed in the future.
}
