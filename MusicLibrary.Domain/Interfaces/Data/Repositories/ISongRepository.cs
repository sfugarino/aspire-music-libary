using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Domain.Interfaces.Data.Repositories;

/// <summary>
/// Interface for the SongRepository, providing methods for managing Song entities.
/// </summary>
public interface ISongRepository : IMongoRepository<Song>
{
    // Add custom Song-specific repository methods here if needed in the future.
}
