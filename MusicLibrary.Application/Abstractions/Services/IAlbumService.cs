using MusicLibrary.Application.DTO;

namespace MusicLibrary.Application.Abstractions.Services;

/// <summary>
/// Interface for album-related business logic.
/// </summary>
public interface IAlbumService
{
    Task<AlbumDTO[]> GetAllAlbumsAsync(CancellationToken ct);
    Task<AlbumDTO?> GetAlbumByIdAsync(string id, CancellationToken ct);
    // Add more album-related service methods as needed
}
