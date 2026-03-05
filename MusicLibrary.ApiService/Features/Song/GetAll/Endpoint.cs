using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Song.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all songs.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly ISongRepository _songRepository;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="songRepository">The song repository dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(ISongRepository songRepository, ILogger<Endpoint> logger)
    {
        _songRepository = songRepository;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/songs");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve all songs.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var songs = await _songRepository.GetAllAsync(ct);
            var songDtos = songs.Select(static s =>
            {
                return new SongDto { 
                    Id = s.Id?.ToString() ?? string.Empty, 
                    Title = s.Title,  
                    Artists = [.. s.Artists], 
                    Genres = [.. s.Genres],   
                    Duration = s.Duration, 
                    AudioFile = s.AudioFile,
                    Lyrics = s.Lyrics,
                };
            });

            await Send.OkAsync(new Response
            {
                Songs = [.. songDtos]
            }, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving all songs.");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
