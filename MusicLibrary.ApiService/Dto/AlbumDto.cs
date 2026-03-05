
namespace MusicLibrary.ApiService.Dto;

/// <summary>
/// Data transfer object representing an album.
/// </summary>
public class AlbumDto
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
    /// Gets or sets the artist ID for the album.
    /// </summary>
    public string? ArtistId { get; set; }

    /// <summary>
    /// Gets or sets the artist name for the album.
    /// </summary>
    public string? ArtistName { get; set; }

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