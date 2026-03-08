
namespace MusicLibrary.Application.DTO;

/// <summary>
/// Data transfer object representing an album.
/// </summary>
public class AlbumDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the album.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the album.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the track IDs for the album.
    /// </summary>
    public string[] Tracks { get; set; } = [];

    /// <summary>
    /// Gets or sets the artist ID for the album.
    /// </summary>
    public string[] Artists { get; set; } = [];

    /// <summary>
    /// Gets or sets the genre IDs associated with the album.
    /// </summary>
    public string[] Genres { get; set; } = [];

    /// <summary>
    /// Gets or sets the cover image URL for the album.
    /// </summary>
    public string? CoverImage { get; set; }

    /// <summary>
    /// Gets or sets the release year of the album.
    /// </summary>
    public int? ReleaseYear { get; set; }

    /// <summary>
    /// Gets or sets the record label of the album.
    /// </summary>
    public string? RecordLabel { get; set; }
}