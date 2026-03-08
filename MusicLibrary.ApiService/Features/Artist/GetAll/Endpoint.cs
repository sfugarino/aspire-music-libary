using FastEndpoints;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Abstractions.Services;
using MusicLibrary.Domain.Schemas;
using MediatR;
using MusicLibrary.Application.Queries.Artists;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all artists.
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
            var artists = await _mediator.Send(new GetAllArtistsQuery(), ct);
            var response = new Response
            {
                Artists = artists
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
