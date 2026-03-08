using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Domain.Schemas;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;


namespace MusicLibrary.Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing Artist entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ArtistRepository"/> class.
/// </remarks>
/// <param name="context">The music library context.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class ArtistRepository(IMusicLibraryContext context, ILogger<ArtistRepository> logger) 
    : MongoRepository<Artist>(context.Artists, logger), IArtistRepository
{
    public async Task<Artist[]> GetAllArtistsWithGenresAsync(CancellationToken ct)
    {
        var genreCollection = _collection.Database.GetCollection<Genre>("genres");

        var result = await _collection.Aggregate()
            .Lookup<Artist, Genre, Artist>(
                genreCollection,
                artist => artist.Genres,
                genre => genre.Id,
                final => final.GenreDetails)
                .ToListAsync(ct);
            

        return [..result];
    }

    public async Task<Artist?> GetArtistWithGenresByIdAsync(string artistId, CancellationToken ct)
    {
        var genreCollection = _collection.Database.GetCollection<Genre>("genres");

        var result = await _collection.Aggregate()
            .Match(artist => artist.Id == artistId)
            .Lookup<Artist, Genre, Artist>(
                genreCollection,
                artist => artist.Genres,
                genre => genre.Id,
                final => final.GenreDetails)
            .FirstOrDefaultAsync(ct);

        return result;
    }
}