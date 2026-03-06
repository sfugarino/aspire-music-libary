using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Domain.Interfaces.Persistence;

/// <summary>
/// Interface for the ArtistRepository, providing methods for managing Artist entities.
/// </summary>
public interface IArtistRepository : IMongoRepository<Artist>
{
    Task<Artist[]> GetArtistsWithGenresAsync(CancellationToken ct);
}
