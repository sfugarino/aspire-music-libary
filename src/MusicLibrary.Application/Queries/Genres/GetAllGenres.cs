using MediatR;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Genres;
public sealed record GetAllGenressQuery(bool IncludeGenres = false) : IQuery<GenreDTO[]>{}


public sealed class GetAllGenresQueryHandler : IQueryHandler<GetAllGenressQuery, GenreDTO[]>
{
    private readonly IGenreRepository _genreRepository;
    public GetAllGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<GenreDTO[]> Handle(GetAllGenressQuery query, CancellationToken ct)
    {
        var genres = await _genreRepository.GetAllAsync(ct);

        var genreDtos = genres.Select(static g => 
        {
            return new GenreDTO 
            { 
                Id = g.Id?.ToString() ?? string.Empty, 
                Name = g.Name, 
                Description = g.Description ?? string.Empty 
            };
        });

        return [.. genreDtos];

    }
}