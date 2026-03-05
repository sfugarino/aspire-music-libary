using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Artist.GetAllWithGenre;

/// <summary>
/// FastEndpoints endpoint for retrieving all artists.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IArtistsService _artistsService;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="artistRepository">The artist repository dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IArtistsService artistsService, ILogger<Endpoint> logger)
    {
        _artistsService = artistsService;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/artists/with-genres");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve all artists.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var artists = await _artistsService.GetArtistsWithGenresAsync(ct);
            var response = new Response
            {
                Artists = artists
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving artists");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
