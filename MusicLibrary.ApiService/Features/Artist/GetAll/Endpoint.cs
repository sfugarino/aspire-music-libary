using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IMongoRepository<Schemas.Artist> _artistRepository;

    public Endpoint(IMongoRepository<Schemas.Artist> artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public override void Configure()
    {
        Get("/artists");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var artists = await _artistRepository.GetAllAsync(ct);
            var artistDtos = artists.Select(a => new ArtistDto
            {
                Id = a.Id?.ToString() ?? string.Empty,
                Name = a.Name,
                Bio = a.Bio,
                Origin = a.Origin,
                Image = a.Image,
                BirthDay = a.BirthDay
            });

            var response = new Response
            {
                Artists = [.. artistDtos]
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch
        {
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
