using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Artists;

public sealed record GetArtistByIdQuery(string Id, bool IncludeGenres = false) : IQuery<ArtistDTO?>{}

public sealed class GetArtistByIdHandler : IQueryHandler<GetArtistByIdQuery, ArtistDTO?>
{
    private readonly IArtistRepository _artistRepository;

    public GetArtistByIdHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ArtistDTO?> Handle(GetArtistByIdQuery query, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetByIdAsync(query.Id, cancellationToken);
        if (artist == null)
        {
            return null;
        }

        var artistDto = new ArtistDTO
        {
            Id = artist.Id?.ToString() ?? string.Empty,
            Name = artist.Name,
            Genres = [.. artist.Genres],
            Bio = artist.Bio,
            Origin = artist.Origin,
            Image = artist.Image,
            BirthDay = artist.BirthDay
        };

        return artistDto;
    }
}