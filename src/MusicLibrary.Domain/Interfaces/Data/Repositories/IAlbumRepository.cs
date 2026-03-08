using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Domain.Interfaces.Data.Repositories;

/// <summary>
/// Interface for the AlbumRepository, providing methods for managing Album entities.
/// </summary>
public interface IAlbumRepository : IMongoRepository<Album>
{
    // Add custom Album-specific repository methods here if needed in the future.
}
