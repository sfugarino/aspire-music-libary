using FastEndpoints;
using MediatR;
using MusicLibrary.Application.Queries.Genres;
namespace MusicLibrary.ApiService.Features.Genre.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all genres.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    /// <summary>
    /// Mediator instance for sending queries and commands.
    /// </summary>
    private readonly IMediator _mediator;
    /// <summary>
    /// Logger instance for logging errors and information.
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="mediator">The mediator dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IMediator mediator, ILogger<Endpoint> logger)
    {
        _mediator = mediator;
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
            var genres = await _mediator.Send(new GetAllGenressQuery(), ct);

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



