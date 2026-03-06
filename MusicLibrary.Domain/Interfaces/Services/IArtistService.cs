using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Interfaces.Services;

/// <summary>
/// Interface for artist-related business logic.
/// </summary>
public interface IArtistsService
{
    Task<ArtistDto[]> GetArtistsAsync(CancellationToken ct);
    Task<ArtistDto?> GetArtistsAsync(string id, CancellationToken ct);
    Task<ArtistDto[]> GetArtistsByNameAsync(string name, CancellationToken ct);
    Task<ArtistWithGenresDto[]> GetArtistsWithGenresAsync(CancellationToken ct);// Define methods for artist-related operations
}   