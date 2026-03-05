using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

/// <summary>
/// Response model for retrieving all artists.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the list of artists returned by the endpoint.
    /// </summary>
    public List<ArtistDto> Artists { get; set; } = new();
}
