using FastEndpoints;
using MediatR;
using MusicLibrary.Application.Queries.Albums;

namespace MusicLibrary.ApiService.Features.Album.GetById;

/// <summary>
/// FastEndpoints endpoint for retrieving an album by ID.
/// </summary>
public class Endpoint : Endpoint<Request, Response>
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
        Get("/api/albums/{Id}");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve an album by ID.
    /// </summary>
    /// <param name="request">The request containing the album ID.</param>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        try
        {
            var album = await _mediator.Send(new GetAlbumByIdQuery(request.Id), ct);

            if (album == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            var response = new Response
            {
                Album = album
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving album by ID: {AlbumId}", request.Id);
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
