namespace MusicLibrary.Domain.Models;

/// <summary>
/// Data transfer object representing a genre.
/// </summary>
public class GenreDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the genre.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the genre.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the genre.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}