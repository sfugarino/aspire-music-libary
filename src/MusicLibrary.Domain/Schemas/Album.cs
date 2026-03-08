using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Schemas;

/// <summary>
/// Represents an album in the music library.
/// </summary>
public class Album : Schema
{
    /// <summary>
    /// Gets or sets the title of the album.
    /// </summary>
    [BsonElement("title")]
    public required string Title { get; set; }


    /// <summary>
    /// Gets or sets list of artist who appear on albumn
    /// </summary>
    [BsonElement("artists")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Artists { get; set; } = []; // references Artist
    
      /// <summary>
    /// Gets or sets the release year of the album.
    /// </summary>
    [BsonElement("releaseYear")]
    public int? ReleaseYear { get; set; }


    /// <summary>
    /// Gets or sets the list of genre IDs associated with the album (references Genre).
    /// </summary>
    [BsonElement("genres")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Genres { get; set; } = []; // references Genre

    /// <summary>
    /// Gets the detailed genre information associated with the artist.
    /// </summary>
    [BsonIgnore]
    public IEnumerable<Genre> GenreDetails { get; set; } = [];

    /// <summary>
    /// Gets or sets the cover image URL of the album.
    /// </summary>
    [BsonElement("coverImage")]
    public string? CoverImage { get; set; }


    /// <summary>
    /// Gets or sets the record label of the album.
    /// </summary>
    [BsonElement("recordLabel")]
    public string? RecordLabel { get; set; }

}
