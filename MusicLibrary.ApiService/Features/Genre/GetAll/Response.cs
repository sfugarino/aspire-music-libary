using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Genre.GetAll;

public class Response
{
    public List<GenreDto> Genres { get; set; } = [];
}