using System.Collections.Generic;
using MusicLibrary.Application.DTO;

namespace MusicLibrary.ApiService.Features.Genre.GetById;

/// <summary>
/// Response model for retrieving a genre by ID.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the genre returned by the endpoint.
    /// </summary>
    public GenreDTO Genre { get; set; } = new();
}
