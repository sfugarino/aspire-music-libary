using System.Collections.Generic;
using MusicLibrary.Application.DTO;

namespace MusicLibrary.ApiService.Features.Song.GetById;

/// <summary>
/// Response model for retrieving a song by ID.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the song returned by the endpoint.
    /// </summary>
    public SongDTO Song { get; set; } = new();
}
