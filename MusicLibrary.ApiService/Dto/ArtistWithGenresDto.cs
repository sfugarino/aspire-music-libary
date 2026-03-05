namespace MusicLibrary.ApiService.Dto;

/// <summary>
/// DTO for artist with joined genres.
/// </summary>
public class ArtistWithGenresDto: ArtistDto
{	
    public List<GenreDto> GenreDetails { get; set; } = new();
}