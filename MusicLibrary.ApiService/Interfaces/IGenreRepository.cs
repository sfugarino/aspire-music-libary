using MusicLibrary.ApiService.Schemas;
using MongoDB.Driver;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for the GenreRepository, providing methods for managing Genre entities.
/// </summary>
public interface IGenreRepository : IMongoRepository<Genre>
{
    // Add custom Genre-specific repository methods here if needed in the future.
}
