using MusicLibrary.Application.DTO;

namespace MusicLibrary.Application.Abstractions.Services
{
    /// <summary>
    /// Service interface for genre-related business logic.
    /// </summary>
    public interface IGenreService
    {
        Task<GenreDTO[]> GetAllGenresAsync(CancellationToken ct);
        Task<GenreDTO?> GetGenreByIdAsync(string id, CancellationToken ct);
    }
}
