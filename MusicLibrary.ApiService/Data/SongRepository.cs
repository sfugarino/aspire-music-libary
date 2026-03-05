using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

public class SongRepository(IMongoDatabase database) 
: MongoRepository<Song>(database, "songs")
{
}