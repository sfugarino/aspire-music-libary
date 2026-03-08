namespace MusicLibrary.Application.DTO;

/// <summary>
/// Data transfer object representing an artist.
/// </summary>
public class ArtistDTO
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

    /// <summary>
    /// Gets or sets the detailed genre information associated with the artist.
    /// </summary>
    public IEnumerable<GenreDTO> GenreDetails { get; set; } = [];
}
