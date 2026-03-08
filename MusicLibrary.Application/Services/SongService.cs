
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Abstractions.Services;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Services;

/// <summary>
/// Service implementation for song-related business logic.
/// </summary>
public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;

    public SongService(ISongRepository songRepository)
    {
        _songRepository = songRepository;
    }

    public async Task<SongDTO[]> GetAllSongsAsync(CancellationToken ct)
    {
        var songs = await _songRepository.GetAllAsync(ct);

        var songDtos = songs.Select(static s => 
        {
            return new SongDTO
            { 
                Id = s.Id?.ToString() ?? string.Empty, 
                Title = s.Title,  
                Artists = [.. s.Artists], 
                Genres = [.. s.Genres],   
                Duration = s.Duration, 
                AudioFile = s.AudioFile,
            };
        });

        return [.. songDtos];

    }

    public async Task<SongDTO?> GetSongByIdAsync(string id, CancellationToken ct)
    {
        var song = await _songRepository.GetByIdAsync(id, ct);
        if (song == null)
        {
            return null;
        }

        return new SongDTO
        {
            Id = song.Id?.ToString() ?? string.Empty, 
            Title = song.Title,  
            Artists = [.. song.Artists], 
            Genres = [.. song.Genres],   
            Duration = song.Duration, 
            AudioFile = song.AudioFile,
        };
    }
}
