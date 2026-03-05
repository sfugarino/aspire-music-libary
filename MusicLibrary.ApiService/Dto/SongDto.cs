namespace MusicLibrary.ApiService.Dto;

/// <summary>
/// Data transfer object representing a song.
/// </summary>
public class SongDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the song.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the song.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the album ID for the song.
    /// </summary>
    public string? AlbumId { get; set; }

    /// <summary>
    /// Gets or sets the artist ID for the song.
    /// </summary>
    public string? ArtistId { get; set; }

    /// <summary>
    /// Gets or sets the artist name for the song.
    /// </summary>
    public string? ArtistName { get; set; }

    /// <summary>
    /// Gets or sets the track number of the song in the album.
    /// </summary>
    public int? TrackNumber { get; set; }

    /// <summary>
    /// Gets or sets the duration of the song in seconds.
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the audio file URL of the song.
    /// </summary>
    public string? AudioFile { get; set; }

    /// <summary>
    /// Gets or sets the lyrics of the song.
    /// </summary>
    public string? Lyrics { get; set; }
}