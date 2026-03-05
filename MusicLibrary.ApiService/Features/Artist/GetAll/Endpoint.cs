using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all artists.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
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
        Get("/api/artists");
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
            var artists = await _artistRepository.GetAllAsync(ct);
            var artistDtos = artists.Select(a => 
            {
                return new ArtistDto 
                {
                    Id = a.Id?.ToString() ?? string.Empty,
                    Name = a.Name,
                    Genres = [.. a.Genres],
                    Bio = a.Bio,
                    Origin = a.Origin,
                    Image = a.Image,
                    BirthDay = a.BirthDay
                };
            });

            var response = new Response
            {
                Artists = [.. artistDtos]
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
