using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Album.GetAll;

/// <summary>
/// Response model for retrieving all albums.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the list of albums returned by the endpoint.
    /// </summary>
    public List<AlbumDto> Albums { get; set; } = new();
}
