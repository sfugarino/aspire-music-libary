using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas;

/// <summary>
/// Represents an album in the music library.
/// </summary>
public class Album
{

    /// <summary>
    /// Gets or sets the unique identifier for the album.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


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
    /// Gets or sets list of artist who appear on albumn
    /// </summary>
    [BsonElement("songs")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Songs { get; set; } = []; // rererenses Song

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
    /// Gets or sets the cover image URL of the album.
    /// </summary>
    [BsonElement("coverImage")]
    public string? CoverImage { get; set; }


    /// <summary>
    /// Gets or sets the record label of the album.
    /// </summary>
    [BsonElement("recordLabel")]
    public string? RecordLabel { get; set; }


    /// <summary>
    /// Gets or sets the creation date of the album record.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }


    /// <summary>
    /// Gets or sets the last update date of the album record.
    /// </summary>
    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether the album is active.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
