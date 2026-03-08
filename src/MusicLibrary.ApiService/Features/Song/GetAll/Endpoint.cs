using FastEndpoints;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Queries.Songs;


namespace MusicLibrary.ApiService.Features.Song.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all songs.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    /// <summary>
    /// Mediator instance for sending queries and commands.
    /// </summary>
    private readonly IQueryHandler<GetAllSongsQuery, SongDTO[]> _queryHandler;
    /// <summary>
    /// Logger instance for logging errors and information. 
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="queryHandler">The query handler dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IQueryHandler<GetAllSongsQuery, SongDTO[]> queryHandler, ILogger<Endpoint> logger)
    {
        _queryHandler = queryHandler;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/songs");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve all songs.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var songs = await _queryHandler.Handle(new GetAllSongsQuery(), ct);

            await Send.OkAsync(new Response
            {
                Songs = songs
            }, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving all songs.");
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
