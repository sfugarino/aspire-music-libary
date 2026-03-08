using FastEndpoints;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Queries.Genres;

namespace MusicLibrary.ApiService.Features.Genre.GetById;

/// <summary>
/// FastEndpoints endpoint for retrieving a genre by ID.
/// </summary>
public class Endpoint : Endpoint<Request, Response>
{
    /// <summary>
    /// Mediator instance for sending queries and commands.
    /// </summary>
    private readonly IQueryHandler<GetGenreByIdQuery, GenreDTO?> _queryHandler;
    /// <summary>
    /// Logger instance for logging errors and information.
    /// </summary>
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="queryHandler">The query handler dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IQueryHandler<GetGenreByIdQuery, GenreDTO?> queryHandler, ILogger<Endpoint> logger)
    {
        _queryHandler = queryHandler;
        _logger = logger;
    }

    /// <summary>
    /// Configures the endpoint route and access.
    /// </summary>
    public override void Configure()
    {
        Get("/api/genres/{Id}");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the GET request to retrieve a genre by ID.
    /// </summary>
    /// <param name="request">The request containing the genre ID.</param>
    /// <param name="ct">Cancellation token.</param>
    public override async Task HandleAsync(Request request, CancellationToken ct)
    {
        try
        {
            var genre = await _queryHandler.Handle(new GetGenreByIdQuery(request.Id), ct);

            if (genre == null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            var response = new Response
            {
                Genre = genre
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving genre by ID: {GenreId}", request.Id);
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
