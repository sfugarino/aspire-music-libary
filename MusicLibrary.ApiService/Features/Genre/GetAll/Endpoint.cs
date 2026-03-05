using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;  

namespace MusicLibrary.ApiService.Features.Genre.GetAll;

/// <summary>
/// FastEndpoints endpoint for retrieving all genres.
/// </summary>
public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IGenreRepository _genreRepository;
    private readonly ILogger<Endpoint> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Endpoint"/> class.
    /// </summary>
    /// <param name="genreRepository">The genre repository dependency.</param>
    /// <param name="logger">The logger instance.</param>
    public Endpoint(IGenreRepository genreRepository, ILogger<Endpoint> logger)
    {
        _genreRepository = genreRepository;
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
            var genres = await _genreRepository.GetAllAsync(ct);
            var genreDtos = genres.Select(static g => 
            {
                return new GenreDto 
                { 
                    Id = g.Id?.ToString() ?? string.Empty, 
                    Name = g.Name, 
                    Description = g.Description ?? string.Empty 
                };
            });

            var response = new Response
            {
                Genres = [.. genreDtos]
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



