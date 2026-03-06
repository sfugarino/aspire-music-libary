using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Interfaces.Services;

/// <summary>
/// Interface for album-related business logic.
/// </summary>
public interface IAlbumService
{
    Task<AlbumDto[]> GetAllAlbumsAsync(CancellationToken ct);
    Task<AlbumDto?> GetAlbumByIdAsync(string id, CancellationToken ct);
    // Add more album-related service methods as needed
}
