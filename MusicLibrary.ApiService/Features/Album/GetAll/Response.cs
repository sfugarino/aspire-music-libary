using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Album.GetAll;

public class Response
{
    public List<AlbumDto> Albums { get; set; } = new();
}
