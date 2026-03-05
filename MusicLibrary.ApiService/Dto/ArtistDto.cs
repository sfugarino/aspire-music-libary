namespace MusicLibrary.ApiService.Dto;

public class ArtistDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Origin { get; set; }
    public string? Image { get; set; }
    public DateOnly? BirthDay { get; set; }
}
