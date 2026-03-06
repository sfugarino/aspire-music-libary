using System.Collections.Generic;
using MusicLibrary.Domain.Models;

namespace MusicLibrary.ApiService.Features.Artist.GetById;

/// <summary>
/// Response model for retrieving an artist by ID.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the artist returned by the endpoint.
    /// </summary>
    public ArtistDto Artists { get; set; } = new();
}
