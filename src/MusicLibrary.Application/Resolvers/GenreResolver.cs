
using HotChocolate;
using HotChocolate.Types;
using MongoDB.Driver;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Application.Resolvers;
    
[ExtendObjectType("Genre")]
public class GenreResolver 
{

    public async Task<Genre[]> GetGenresAsync(
      [Parent] Artist artist,
      [Service] IGenreRepository genreRepository,
      CancellationToken cancellationToken)
    {
        var genres = await genreRepository.FindAsync(FilterBuilder.GetFilter(artist.Genres), cancellationToken);
        return [.. genres];
    }

    public async Task<Genre[]> GetGenresAsync(
      [Parent] Album album,
      [Service] IGenreRepository genreRepository,
      CancellationToken cancellationToken)
    {
        var genres = await genreRepository.FindAsync(FilterBuilder.GetFilter(album.Genres), cancellationToken);
        return [.. genres];
    }

    public async Task<Genre[]> GetGenresAsync(
      [Parent] Song song,
      [Service] IGenreRepository genreRepository,
      CancellationToken cancellationToken)
    {        
        var genres = await genreRepository.FindAsync(FilterBuilder.GetFilter(song.Genres), cancellationToken);
        return [.. genres];
    }

    private static class FilterBuilder
    {
        public static FilterDefinition<Genre> GetFilter(List<string>genreIds)
        {
            var filterDefinitionBuilder = Builders<Genre>.Filter;
            var filter = filterDefinitionBuilder.In<string>(genre => genre.Id!, genreIds);
            return filter;
        }
    }
}