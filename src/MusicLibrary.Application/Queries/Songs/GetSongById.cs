using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Songs;

public sealed record GetSongByIdQuery(string Id, bool IncludeGenres = false) : IQuery<SongDTO?>{}

public sealed class GetSongByIdHandler : IQueryHandler<GetSongByIdQuery, SongDTO?>
{
    private readonly ISongRepository _songRepository;

    public GetSongByIdHandler(ISongRepository songRepository)
    {
        _songRepository = songRepository;
    }

    public async Task<SongDTO?> Handle(GetSongByIdQuery query, CancellationToken ct)
    {
        var song = await _songRepository.GetByIdAsync(query.Id, ct);
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