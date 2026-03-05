namespace MusicLibrary.ApiService.Dto;

public class AlbumDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? ArtistId { get; set; } 
    public string? ArtistName { get; set; } 
    public string? CoverImage { get; set; } 
    public int? ReleaseYear { get; set; }
    public string? RecordLabel { get; set; }
}