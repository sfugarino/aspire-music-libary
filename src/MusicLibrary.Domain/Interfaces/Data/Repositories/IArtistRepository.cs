using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Domain.Interfaces.Data.Repositories;

/// <summary>
/// Interface for the ArtistRepository, providing methods for managing Artist entities.
/// </summary>
public interface IArtistRepository : IMongoRepository<Artist>
{
    /// <summary>
    /// Retrieves all artists along with their associated genre details.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An array of artists with their genre details.</returns>
    Task<Artist[]> GetAllArtistsWithGenresAsync(CancellationToken ct);
}
