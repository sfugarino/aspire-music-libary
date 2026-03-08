using System.Collections.Generic;
using MusicLibrary.Application.DTO;

namespace MusicLibrary.ApiService.Features.Album.GetById;

/// <summary>
/// Response model for retrieving an album by ID.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the album returned by the endpoint.
    /// </summary>
    public AlbumDTO Album { get; set; } = new();
}
