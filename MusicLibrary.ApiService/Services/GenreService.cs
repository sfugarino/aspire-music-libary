using MusicLibrary.Domain.Interfaces.Services;
using MusicLibrary.Domain.Interfaces.Persistence;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.ApiService.Services;

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

    public async Task<GenreDto[]> GetAllGenresAsync(CancellationToken ct)
    {
        var genres = await _genreRepository.GetAllAsync(ct);

        var genreDtos = genres.Select(static g => 
        {
            return new GenreDto 
            { 
                Id = g.Id?.ToString() ?? string.Empty, 
                Name = g.Name, 
                Description = g.Description ?? string.Empty 
            };
        });

        return [.. genreDtos];

    }

    public async Task<GenreDto?> GetGenreByIdAsync(string id, CancellationToken ct)
    {
        var genre = await _genreRepository.GetByIdAsync(id, ct);
        if (genre == null)
        {
            return null;
        }

        return new GenreDto
        {
            Id = genre.Id?.ToString() ?? string.Empty, 
            Name = genre.Name, 
            Description = genre.Description ?? string.Empty 
        };
    }
}