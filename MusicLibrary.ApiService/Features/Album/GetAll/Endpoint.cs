using FastEndpoints;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Features.Album.GetAll;

public class Endpoint : EndpointWithoutRequest<Response>
{
    private readonly IMongoRepository<Schemas.Album> _albumRepository;

    public Endpoint(IMongoRepository<Schemas.Album> albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public override void Configure()
    {
        Get("/albums");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var albums = await _albumRepository.GetAllAsync(ct);
            var albumDtos = albums.Select(a => new AlbumDto
            {
                Id = a.Id?.ToString() ?? string.Empty,
                Title = a.Title,
                ArtistId = a.ArtistId,
                ArtistName = a.ArtistName,
                CoverImage = a.CoverImage,
                ReleaseYear = a.ReleaseYear,
                RecordLabel = a.RecordLabel
            });

            var response = new Response
            {
                Albums = [.. albumDtos]
            };

            await Send.OkAsync(response, cancellation: ct);
        }
        catch 
        {
            await Send.ErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}
