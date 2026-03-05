using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Song.GetAll;

public class Response
{
    public List<SongDto> Songs { get; set; } = new();
}
