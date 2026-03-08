using FastEndpoints;
using MediatR;
using MusicLibrary.Application.Queries.Albums;


namespace MusicLibrary.ApiService.Features.Album.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all albums.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IMediator _mediator;
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
        Get("/api/albums");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve all albums.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var albums = await _mediator.Send(new GetAllAlbumsQuery(), ct);
            var response = new Response
            {
                Albums = albums
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving albums");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
