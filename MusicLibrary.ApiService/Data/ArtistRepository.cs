using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class ArtistRepository(IMongoDatabase database) 
: MongoRepository<Artist>(database, "artists")
{
}