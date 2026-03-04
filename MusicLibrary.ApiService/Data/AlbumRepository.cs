using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class AlbumRepository(IMongoDatabase database, DatabaseSettings dbSettings) : MongoRepository<Album>(database, dbSettings.AlbumCollectionName)
{
}