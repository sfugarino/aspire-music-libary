using System.Collections.Generic;
using MusicLibrary.Application.DTO;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

/// <summary>
/// Response model for retrieving all artists.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the list of artists returned by the endpoint.
    /// </summary>
    public ArtistDTO[] Artists { get; set; } = [];
}
