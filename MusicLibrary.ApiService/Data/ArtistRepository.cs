using System.Reflection.Metadata.Ecma335;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MusicLibrary.ApiService.Dto;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Repository for managing Artist entities in MongoDB.
/// </summary>
public class ArtistRepository(IMongoDatabase database, ILogger<ArtistRepository> logger) 
    : MongoRepository<Artist>(database, "artists", logger), IArtistRepository
{
    public async Task<Artist[]> GetArtistsWithGenresAsync(CancellationToken ct)
    {
        var artistCollection = _collection.AsQueryable();
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
}