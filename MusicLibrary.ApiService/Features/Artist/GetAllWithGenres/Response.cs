using MusicLibrary.Application.DTO;

public class Response
{
    /// <summary>
    /// Gets or sets the list of artists returned by the endpoint.
    /// </summary>
    public ArtistDTO[] Artists { get; set; } = [];
}       