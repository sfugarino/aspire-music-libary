using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;


namespace MusicLibrary.ApiService.Features.Song.GetAll;

/// <summary>
/// Response model for retrieving all songs.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the list of songs returned by the endpoint.
    /// </summary>
    public List<SongDto> Songs { get; set; } = new();
}
