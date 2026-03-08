using MusicLibrary.Application.DTO;

namespace MusicLibrary.Application.Abstractions.Services
{
    /// <summary>
    /// Service interface for song-related business logic.
    /// </summary>
    public interface ISongService
    {
        Task<SongDTO[]> GetAllSongsAsync(CancellationToken ct);
        Task<SongDTO?> GetSongByIdAsync(string id, CancellationToken ct);
    }
}
