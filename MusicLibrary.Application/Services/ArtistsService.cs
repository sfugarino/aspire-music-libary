using MusicLibrary.Application.DTO;
using MusicLibrary.Application.Abstractions.Services;
using MusicLibrary.Domain.Interfaces.Data.Repositories;

namespace MusicLibrary.Application.Services;

public class ArtistsService : IArtistsService
{
    private readonly IArtistRepository _artistRepository;

    public ArtistsService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    // Implement methods for artist-related operations
   /// <summary>
    /// Gets all artists.   
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Array of ArtistDTO.</returns>
    public async Task<ArtistDTO[]> GetArtistsAsync(CancellationToken ct)
    {
        var artists = _artistRepository.GetAllAsync(ct)
            .Result
            .Select(a => new ArtistDTO
            {
                Id = a.Id?.ToString() ?? string.Empty,
                Name = a.Name,
                Genres = [.. a.Genres],
                Bio = a.Bio,
                Origin = a.Origin,
                Image = a.Image,
                BirthDay = a.BirthDay,

            });
            
        return artists.ToArray();
    }
    
    /// <summary>
    /// Gets an artist by ID.
    /// </summary>
    /// <param name="id">The artist ID.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>ArtistDTO or null if not found.</returns>
    public async Task<ArtistDTO?> GetArtistAsync(string id, CancellationToken ct)
    {
        var artist = await _artistRepository.GetByIdAsync(id, ct);
        if (artist == null)
        {
            return null;
        }

        var artistDto = new ArtistDTO
        {
            Id = artist.Id?.ToString() ?? string.Empty,
            Name = artist.Name,
            Genres = [.. artist.Genres],
            Bio = artist.Bio,
            Origin = artist.Origin,
            Image = artist.Image,
            BirthDay = artist.BirthDay
        };

        return artistDto;
    }

    public async Task<ArtistDTO[]> GetArtistsWithGenresAsync(CancellationToken ct)
    {
        var artists = await _artistRepository.GetAllArtistsWithGenresAsync(ct);

        var artistDtos = artists.Select(a => new ArtistDTO
        {
            Id = a.Id?.ToString() ?? string.Empty,
            Name = a.Name,
            Genres = [.. a.Genres],
            Bio = a.Bio,
            Origin = a.Origin,
            Image = a.Image,
            BirthDay = a.BirthDay,
            GenreDetails = a.GenreDetails.Select(g => new GenreDTO
            {
                Id = g.Id?.ToString() ?? string.Empty,
                Name = g.Name,
                Description = g.Description
            }).ToArray()
        });

        return artistDtos.ToArray();
    }

}