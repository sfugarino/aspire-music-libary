namespace MusicLibrary.ApiService.Features.Genre.GetById;

/// <summary>
/// Request model for retrieving a genre by ID.
/// </summary>
public class Request
{
    /// <summary>
    /// Gets or sets the genre ID to retrieve.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}