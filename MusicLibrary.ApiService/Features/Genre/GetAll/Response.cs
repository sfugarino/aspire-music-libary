using MusicLibrary.Domain.Models;

namespace MusicLibrary.ApiService.Features.Genre.GetAll;

/// <summary>
/// Response model for retrieving all genres.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the list of genres returned by the endpoint.
    /// </summary>
    public List<GenreDto> Genres { get; set; } = [];
}