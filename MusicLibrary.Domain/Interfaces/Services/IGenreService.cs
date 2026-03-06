using MusicLibrary.Domain.Models;


namespace MusicLibrary.Domain.Interfaces.Services
{
    /// <summary>
    /// Service interface for genre-related business logic.
    /// </summary>
    public interface IGenreService
    {
        Task<GenreDto[]> GetAllGenresAsync(CancellationToken ct);
        Task<GenreDto?> GetGenreByIdAsync(string id, CancellationToken ct);
    }
}
