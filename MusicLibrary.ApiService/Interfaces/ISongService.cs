using System.Collections.Generic;
using System.Threading.Tasks;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Interfaces
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
