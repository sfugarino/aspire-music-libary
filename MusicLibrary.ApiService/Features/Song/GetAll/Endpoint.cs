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
    private readonly ISongService _songService;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="songService">The song service dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(ISongService songService, ILogger<Endpoint> logger)
    {
        _songService = songService;
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
            var songs = await _songService.GetAllSongsAsync(ct);

            await Send.OkAsync(new Response
            {
                Songs = [.. songs]
            }, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving all songs.");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
