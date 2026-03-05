namespace MusicLibrary.ApiService.Features.Artist.GetById;

/// <summary>
/// Request model for retrieving an artist by ID.
/// </summary>
public class Request
{
    /// <summary>
    /// Gets or sets the artist ID to retrieve.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}