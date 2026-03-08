using MediatR;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Albums;
public sealed record GetAllAlbumsQuery(bool IncludeGenres = false) : IQuery<AlbumDTO[]>{}


public sealed class GetAllAlbumsQueryHandler : IQueryHandler<GetAllAlbumsQuery, AlbumDTO[]>
{
    private readonly IAlbumRepository _albumRepository;
    public GetAllAlbumsQueryHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<AlbumDTO[]> Handle(GetAllAlbumsQuery query, CancellationToken ct)
    {

        var albums = await _albumRepository.GetAllAsync(ct);

        var albumDtos = albums.Select(static a => 
        {
            return new AlbumDTO 
            {   
                Id = a.Id?.ToString() ?? string.Empty,
                Title = a.Title,
                Artists = [.. a.Artists],
                Genres = [.. a.Genres],
                CoverImage = a.CoverImage,
                ReleaseYear = a.ReleaseYear,
                RecordLabel = a.RecordLabel
            };
        });
        return [.. albumDtos];

    }
}