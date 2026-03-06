using MongoDB.Driver;
using MusicLibrary.Domain.Models;
using MusicLibrary.Domain.Interfaces.Services;
using MusicLibrary.Domain.Interfaces.Persistence;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.ApiService.Services;

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
    /// <returns>Array of ArtistDto.</returns>
    public async Task<ArtistDto[]> GetArtistsAsync(CancellationToken ct)
    {
        var artists = _artistRepository.GetAllAsync(ct)
            .Result
            .Select(a => new ArtistDto
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
    /// <returns>ArtistDto or null if not found.</returns>
    public async Task<ArtistDto?> GetArtistsAsync(string id, CancellationToken ct)
    {
        var artist = await _artistRepository.GetByIdAsync(id, ct);
        if (artist == null)
        {
            return null;
        }

        var artistDto = new ArtistDto
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

    /// <summary>
    /// Gets an artist by name.
    /// </summary>
    /// <param name="name">The artist name.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>ArtistDto or null if not found.</returns>
    public async Task<ArtistDto[]> GetArtistsByNameAsync(string name, CancellationToken ct)
    {
        var filter = Builders<Artist>.Filter.Eq(a => a.Name, name);
        var artists = await _artistRepository.FindAsync(filter,ct);            
        var artistDtos = artists.Select(a => new ArtistDto
            {
                Id = a.Id?.ToString() ?? string.Empty,
                Name = a.Name,
                Genres = [.. a.Genres],
                Bio = a.Bio,
                Origin = a.Origin,
                Image = a.Image,
                BirthDay = a.BirthDay,

            });
            
        return [.. artistDtos];
    }

	/// <summary>
	/// Gets artists with their genres joined.
	/// </summary>
	/// <returns>A list of anonymous objects or DTOs containing artist and genre info.</returns>
    public async Task<ArtistWithGenresDto[]> GetArtistsWithGenresAsync(CancellationToken ct)
    {
        var artistsWithGenres = await _artistRepository.GetArtistsWithGenresAsync(ct);
        var result = artistsWithGenres.Select(awg => new ArtistWithGenresDto
        {
            Id = awg.Id?.ToString() ?? string.Empty,
            Name = awg.Name,
            Bio = awg.Bio,
            Origin = awg.Origin,
            Image = awg.Image,
            BirthDay = awg.BirthDay,
            GenreDetails = awg.GenreDetails.Select(g => new GenreDto
            {
                Id = g.Id?.ToString() ?? string.Empty,
                Name = g.Name,
                Description = g.Description ?? string.Empty
            }).ToList()
        });
        return [..result];
    }
}