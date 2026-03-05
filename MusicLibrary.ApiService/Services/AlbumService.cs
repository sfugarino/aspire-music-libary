using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicLibrary.ApiService.Services;

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

    public async Task<AlbumDto[]> GetAllAlbumsAsync(CancellationToken ct)
    {
        var albums = await _albumRepository.GetAllAsync(ct);

        var albumDtos = albums.Select(static a => 
        {
            return new AlbumDto 
            {   
                Id = a.Id?.ToString() ?? string.Empty,
                Title = a.Title,
                Artists = [.. a.Artists],
                Tracks = [.. a.Songs],
                Genres = [.. a.Genres],
                CoverImage = a.CoverImage,
                ReleaseYear = a.ReleaseYear,
                RecordLabel = a.RecordLabel
            };
        });
        return [.. albumDtos];

    }

    public async Task<AlbumDto?> GetAlbumByIdAsync(string id, CancellationToken ct)
    {
        var album = await _albumRepository.GetByIdAsync(id, ct);
        if (album == null)
        {
            return null;
        }

        return new AlbumDto
        {
            Id = album.Id?.ToString() ?? string.Empty,
            Title = album.Title,
            Artists = [.. album.Artists],
            Tracks = [.. album.Songs],
            Genres = [.. album.Genres],
            CoverImage = album.CoverImage,
            ReleaseYear = album.ReleaseYear,
            RecordLabel = album.RecordLabel
        };
    }

    // Add more album-related business logic methods as needed
}
