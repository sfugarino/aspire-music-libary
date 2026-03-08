using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Query;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Queries.Genres;

public sealed record GetGenreByIdQuery(string Id) : IQuery<GenreDTO?>{}

public sealed class GetGenreByIdHandler : IQueryHandler<GetGenreByIdQuery, GenreDTO?>
{
    private readonly IGenreRepository _genreRepository;

    public GetGenreByIdHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<GenreDTO?> Handle(GetGenreByIdQuery query, CancellationToken ct)
    {
        var genre = await _genreRepository.GetByIdAsync(query.Id, ct);
        if (genre == null)
        {
            return null;
        }

        return new GenreDTO
        {
            Id = genre.Id?.ToString() ?? string.Empty, 
            Name = genre.Name, 
            Description = genre.Description ?? string.Empty 
        };
    }
}