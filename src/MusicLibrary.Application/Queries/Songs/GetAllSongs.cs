using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Songs;
public sealed record GetAllSongsQuery(bool IncludeGenres = false) : IQuery<SongDTO[]>{}


public sealed class GetAllSongsQueryHandler : IQueryHandler<GetAllSongsQuery, SongDTO[]>
{
    private readonly ISongRepository _songRepository;
    public GetAllSongsQueryHandler(ISongRepository songRepository)
    {
        _songRepository = songRepository;
    }

    public async Task<SongDTO[]> Handle(GetAllSongsQuery query, CancellationToken ct)
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
}