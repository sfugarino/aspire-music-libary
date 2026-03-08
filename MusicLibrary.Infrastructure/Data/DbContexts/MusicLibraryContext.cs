using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MusicLibrary.Domain.Config;
using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Data.DbContexts;
public class MusicLibraryContext : IMusicLibraryContext
{
    public MusicLibraryContext(DatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);

        this.Artists = database.GetCollection<Artist>("artists");
        this.Albums = database.GetCollection<Album>("albums");
        this.Songs = database.GetCollection<Song>("songs");            
        this.Genres = database.GetCollection<Genre>("genres");
    }

    public IMongoCollection<Artist> Artists { get; init; }
    public IMongoCollection<Album> Albums { get; init; }
    public IMongoCollection<Song> Songs { get; init; }
    public IMongoCollection<Genre> Genres { get; init; }
}