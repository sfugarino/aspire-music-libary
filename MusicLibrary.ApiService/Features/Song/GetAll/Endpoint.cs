using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Song.GetAll;

public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IMongoRepository<Schemas.Song> _songRepository;

    public Endpoint(IMongoRepository<Schemas.Song> songRepository)
    {
        _songRepository = songRepository;
    }

    public override void Configure()
    {
        Get("/songs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var songs = await _songRepository.GetAllAsync(ct);
            var songDtos = songs.Select(s => new SongDto
            {
                Id = s.Id?.ToString() ?? string.Empty,
                Title = s.Title,
                AlbumId = s.AlbumId,
                ArtistId = s.ArtistId,
                TrackNumber = s.TrackNumber,
                Duration = s.Duration,
                AudioFile = s.AudioFile,
                Lyrics = s.Lyrics,
                ArtistName = s.ArtistName
            });

            var response = new Response
            {
                Songs = [.. songDtos]
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch 
        {
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
