using MusicLibrary.Application.Abstractions.Services;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Application.DTO;

namespace MusicLibrary.Application.Services;

/// <summary>
/// Service implementation for genre-related business logic.
/// </summary>
public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<GenreDTO[]> GetAllGenresAsync(CancellationToken ct)
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

    public async Task<GenreDTO?> GetGenreByIdAsync(string id, CancellationToken ct)
    {
        var genre = await _genreRepository.GetByIdAsync(id, ct);
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