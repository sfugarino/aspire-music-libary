using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Albums;

public sealed record GetAlbumByIdQuery(string Id, bool IncludeGenres = false) : IQuery<AlbumDTO?>{}

public sealed class GetAlbumByIdHandler : IQueryHandler<GetAlbumByIdQuery, AlbumDTO?>
{
    private readonly IAlbumRepository _albumRepository;

    public GetAlbumByIdHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<AlbumDTO?> Handle(GetAlbumByIdQuery query, CancellationToken ct)
    {
        var album = await _albumRepository.GetByIdAsync(query.Id, ct);
        if (album == null)
        {
            return null;
        }

        return new AlbumDTO
        {
            Id = album.Id?.ToString() ?? string.Empty,
            Title = album.Title,
            Artists = [.. album.Artists],
            Genres = [.. album.Genres],
            CoverImage = album.CoverImage,
            ReleaseYear = album.ReleaseYear,
            RecordLabel = album.RecordLabel
        };
    }
}