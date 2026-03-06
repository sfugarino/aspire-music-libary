using FastEndpoints;
using MusicLibrary.Domain.Interfaces.Services;
namespace MusicLibrary.ApiService.Features.Genre.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all genres.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IGenreService _genreService;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="genreService">The genre service dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IGenreService genreService, ILogger<Endpoint> logger)
    {
        _genreService = genreService;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/genres");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve all genres.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var genres = await _genreService.GetAllGenresAsync(ct);

            var response = new Response
            {
                Genres = [.. genres]
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving all genres.");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}



