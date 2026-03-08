namespace MusicLibrary.ApiService.Features.Song.GetById;

/// <summary>
/// Request model for retrieving a song by ID.
/// </summary>
public class Request
{
    /// <summary>
    /// Gets or sets the song ID to retrieve.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}