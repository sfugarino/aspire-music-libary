using System.Collections.Generic;
using MusicLibrary.ApiService.Dto;

namespace MusicLibrary.ApiService.Features.Artist.GetAll;

public class Response
{
    public List<ArtistDto> Artists { get; set; } = new();
}
