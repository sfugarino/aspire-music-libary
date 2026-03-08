using FastEndpoints;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Queries.Genres;
namespace MusicLibrary.ApiService.Features.Genre.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all genres.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    /// <summary>
    /// Logger instance for logging errors and information.
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    private readonly IQueryHandler<GetAllGenressQuery, GenreDTO[]> _queryHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="mediator">The mediator dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IQueryHandler<GetAllGenressQuery, GenreDTO[]> queryHandler, ILogger<Endpoint> logger)
    {
        _queryHandler = queryHandler;
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
            var genres = await _queryHandler.Handle(new GetAllGenressQuery(), ct);

            var response = new Response
            {
                Genres = genres
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



