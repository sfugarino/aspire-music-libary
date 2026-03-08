using FastEndpoints;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Queries.Songs;

namespace MusicLibrary.ApiService.Features.Song.GetById;

/// <summary>
/// FastEndpoints endpoint for retrieving a song by ID.
/// </summary>
public class Endpoint : Endpoint<Request, Response>
{
    /// <summary>
    /// Mediator instance for sending queries and commands.
    /// </summary>
    private readonly IQueryHandler<GetSongByIdQuery, SongDTO?> _queryHandler;
    /// <summary>
    /// Logger instance for logging errors and information.
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="queryHandler">The query handler dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IQueryHandler<GetSongByIdQuery, SongDTO?> queryHandler, ILogger<Endpoint> logger)
    {
        _queryHandler = queryHandler;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/songs/{Id}");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve a song by ID.
    /// </summary>
    /// <param name="request">The request containing the song ID.</param>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        try
        {
            var song = await _queryHandler.Handle(new GetSongByIdQuery(request.Id), ct);

            if (song == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            var response = new Response
            {
                Song = song
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving song by ID: {SongId}", request.Id);
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
