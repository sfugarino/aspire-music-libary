using MusicLibrary.Application.DTO;

namespace MusicLibrary.Application.Abstractions.Services;

/// <summary>
/// Interface for artist-related business logic.
/// </summary>
public interface IArtistsService
{
    Task<ArtistDTO[]> GetArtistsAsync(CancellationToken ct);
    Task<ArtistDTO?> GetArtistAsync(string id, CancellationToken ct);
    Task<ArtistDTO[]> GetArtistsWithGenresAsync(CancellationToken ct);
}   