using MusicLibrary.ApiService.Schemas;
using MongoDB.Driver;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for the ArtistRepository, providing methods for managing Artist entities.
/// </summary>
public interface IArtistRepository : IMongoRepository<Artist>
{
    Task<Artist[]> GetArtistsWithGenresAsync(CancellationToken ct);
}
