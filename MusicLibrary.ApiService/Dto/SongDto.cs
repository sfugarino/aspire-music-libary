namespace MusicLibrary.ApiService.Dto;

public class SongDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? AlbumId { get; set; }
    public string? ArtistId { get; set; }
    public string? ArtistName { get; set; }
    public int? TrackNumber { get; set; }
    public int? Duration { get; set; }
    public string? AudioFile { get; set; }
    public string? Lyrics { get; set; }
}