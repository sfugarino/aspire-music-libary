using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Schemas;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicLibrary.ApiService.Interfaces;

/// <summary>
/// Interface for album-related business logic.
/// </summary>
public interface IAlbumService
{
    Task<AlbumDto[]> GetAllAlbumsAsync(CancellationToken ct);
    Task<AlbumDto?> GetAlbumByIdAsync(string id, CancellationToken ct);
    // Add more album-related service methods as needed
}
