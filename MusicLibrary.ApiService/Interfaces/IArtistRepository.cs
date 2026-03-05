using MusicLibrary.ApiService.Schemas;
using MongoDB.Driver;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for the ArtistRepository, providing methods for managing Artist entities.
/// </summary>
public interface IArtistRepository : IMongoRepository<Artist>
{
    // Add custom Artist-specific repository methods here if needed in the future.
}
