using System.Collections.Generic;
using System.Threading.Tasks;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Interfaces
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
