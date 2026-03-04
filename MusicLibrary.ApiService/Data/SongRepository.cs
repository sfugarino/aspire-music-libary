using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class SongRepository(IMongoDatabase database, DatabaseSettings dbSettings) : MongoRepository<Song>(database, dbSettings.SongCollectionName)
{
}