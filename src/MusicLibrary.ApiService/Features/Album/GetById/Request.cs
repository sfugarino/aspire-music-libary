namespace MusicLibrary.ApiService.Features.Album.GetById;

/// <summary>
/// Request model for retrieving an album by ID.
/// </summary>
public class Request
{
    /// <summary>
    /// Gets or sets the album ID to retrieve.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}