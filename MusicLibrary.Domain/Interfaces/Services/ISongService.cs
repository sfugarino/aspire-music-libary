using MusicLibrary.Domain.Models;

namespace MusicLibrary.Domain.Interfaces.Services
{
    /// <summary>
    /// Service interface for song-related business logic.
    /// </summary>
    public interface ISongService
    {
        Task<SongDto[]> GetAllSongsAsync(CancellationToken ct);
        Task<SongDto?> GetSongByIdAsync(string id, CancellationToken ct);
    }
}
