using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class GenreRepository(IMongoDatabase database, DatabaseSettings dbSettings) : MongoRepository<Genre>(database, dbSettings.GenreCollectionName)
{
}