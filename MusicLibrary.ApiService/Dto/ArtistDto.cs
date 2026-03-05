namespace MusicLibrary.ApiService.Dto;

/// <summary>
/// Data transfer object representing an artist.
/// </summary>
public class ArtistDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the artist.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the artist.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the biography of the artist.
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// Gets or sets the origin of the artist.
    /// </summary>
    public string? Origin { get; set; }

    /// <summary>
    /// Gets or sets the image URL of the artist.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the birth date of the artist.
    /// </summary>
    public DateOnly? BirthDay { get; set; }

    /// <summary>
    /// Gets or sets the genre IDs associated with the artist.
    /// </summary>
    public string[]Genres { get; set; } = [];
}
