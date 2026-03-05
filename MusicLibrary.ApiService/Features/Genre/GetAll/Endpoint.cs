using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;  

namespace MusicLibrary.ApiService.Features.Genre.GetAll;

public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IMongoRepository<Schemas.Genre> _genreRepository;

    public Endpoint(IMongoRepository<Schemas.Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public override void Configure()
    {
        Get("/genres");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var genres = await _genreRepository.GetAllAsync(ct);
            var genreDtos = genres.Select(g => new GenreDto
            {
                Id = g.Id?.ToString() ?? string.Empty,
                Name = g.Name,
                Description = g.Description ?? string.Empty
            });

            var response = new Response
            {
                Genres = [.. genreDtos]
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch
        {
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}



