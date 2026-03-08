using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Artists;
public sealed record GetAllArtistsQuery(bool IncludeGenres = false) : IQuery<ArtistDTO[]>{}


public sealed class GetAllArtistsQueryHandler : IQueryHandler<GetAllArtistsQuery, ArtistDTO[]>
{
    private readonly IArtistRepository _artistRepository;
    public GetAllArtistsQueryHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ArtistDTO[]> Handle(GetAllArtistsQuery query, CancellationToken cancellationToken)
    {
        if(query.IncludeGenres)
        {
            var artistsWithGenres = await _artistRepository.GetAllArtistsWithGenresAsync(cancellationToken);

            var artistDtos = artistsWithGenres.Select(a => new ArtistDTO
            {
                Id = a.Id?.ToString() ?? string.Empty,
                Name = a.Name,
                Genres = [..a.Genres],
                GenreDetails = [.. a.GenreDetails.Select(g => new GenreDTO
                {
                    Id = g.Id?.ToString() ?? string.Empty,
                    Name = g.Name,
                    Description = g.Description ?? string.Empty
                })],
                Bio = a.Bio,
                Origin = a.Origin,
                Image = a.Image,
                BirthDay = a.BirthDay,

            });

            return[..artistDtos];
        }
        else
        {      
            var artists = _artistRepository.GetAllAsync(cancellationToken)
                .Result
                .Select(a => new ArtistDTO
                {
                    Id = a.Id?.ToString() ?? string.Empty,
                    Name = a.Name,
                    Genres = [.. a.Genres],
                    Bio = a.Bio,
                    Origin = a.Origin,
                    Image = a.Image,
                    BirthDay = a.BirthDay,

                });

            return[..artists];
        }    


    }
}