using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Abstractions.Services;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Services;

/// <summary>
/// Service for album-related business logic.
/// </summary>
public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<AlbumDTO[]> GetAllAlbumsAsync(CancellationToken ct)
    {
        var albums = await _albumRepository.GetAllAsync(ct);

        var albumDtos = albums.Select(static a => 
        {
            return new AlbumDTO 
            {   
                Id = a.Id?.ToString() ?? string.Empty,
                Title = a.Title,
                Artists = [.. a.Artists],
                Genres = [.. a.Genres],
                CoverImage = a.CoverImage,
                ReleaseYear = a.ReleaseYear,
                RecordLabel = a.RecordLabel
            };
        });
        return [.. albumDtos];

    }

    public async Task<AlbumDTO?> GetAlbumByIdAsync(string id, CancellationToken ct)
    {
        var album = await _albumRepository.GetByIdAsync(id, ct);
        if (album == null)
        {
            return null;
        }

        return new AlbumDTO
        {
            Id = album.Id?.ToString() ?? string.Empty,
            Title = album.Title,
            Artists = [.. album.Artists],
            Genres = [.. album.Genres],
            CoverImage = album.CoverImage,
            ReleaseYear = album.ReleaseYear,
            RecordLabel = album.RecordLabel
        };
    }

    // Add more album-related business logic methods as needed
}
