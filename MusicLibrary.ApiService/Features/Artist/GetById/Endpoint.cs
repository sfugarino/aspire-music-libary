using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Artist.GetById;

/// <summary>
/// FastEndpoints endpoint for retrieving an artist by ID.
/// </summary>
public class Endpoint : Endpoint<Request, Response>
{
    private readonly IArtistRepository _artistRepository;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="artistRepository">The artist repository dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IArtistRepository artistRepository, ILogger<Endpoint> logger)
    {
        _artistRepository = artistRepository;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/artists/{Id}");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve an artist by ID.
    /// </summary>
    /// <param name="request">The request containing the artist ID.</param>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        try
        {
            var artist = await _artistRepository.GetByIdAsync(request.Id, ct);
            var artistDto = new ArtistDto
            {
                Id = artist.Id?.ToString() ?? string.Empty,
                Name = artist.Name,
                Bio = artist.Bio,
                Origin = artist.Origin,
                Image = artist.Image,
                BirthDay = artist.BirthDay
            };

            var response = new Response
            {
                Artists = artistDto
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving artist by ID: {ArtistId}", request.Id);
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
