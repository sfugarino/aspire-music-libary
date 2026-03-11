using FastEndpoints;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Queries.Artists;
using MusicLibrary.Application.Abstractions.Messaging;

namespace MusicLibrary.ApiService.Features.Artist.GetById;

/// <summary>
/// FastEndpoints endpoint for retrieving an artist by ID.
/// </summary>
public class Endpoint : Endpoint<Request, Response>
{
    /// <summary>
    /// Mediator instance for sending queries and commands.
    /// </summary>
    private readonly IQueryHandler<GetArtistByIdQuery, ArtistDTO?> _queryHandler;
    /// <summary>
    /// Logger instance for logging errors and information.
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="queryHandler">The query handler dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IQueryHandler<GetArtistByIdQuery, ArtistDTO?> queryHandler, ILogger<Endpoint> logger)
    {
        _queryHandler = queryHandler;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/artists/{Id}");
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
            var artist = await _queryHandler.Handle(new GetArtistByIdQuery(request.Id), ct);

            if (artist == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            var response = new Response
            {
                Artists = artist
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
