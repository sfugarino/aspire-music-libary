using MongoDB.Driver;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Domain.Interfaces.Data.DbContexts;

public interface IMusicLibraryContext
{
    
    IMongoCollection<Artist> Artists { get; }
    IMongoCollection<Album> Albums { get; }
    IMongoCollection<Song> Songs { get; }
    IMongoCollection<Genre> Genres { get; }
}