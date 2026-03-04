using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class ArtistRepository(IMongoDatabase database, DatabaseSettings dbSettings) : MongoRepository<Artist>(database, dbSettings.ArtistCollectionName)
{
}