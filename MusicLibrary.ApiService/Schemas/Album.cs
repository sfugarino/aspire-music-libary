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
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    /// <summary>
    /// Gets or sets the unique identifier for the album.
    /// </summary>
    public string? Id { get; set; }

    [BsonElement("title")]
    /// <summary>
    /// Gets or sets the title of the album.
    /// </summary>
    public required string Title { get; set; }

    [BsonElement("artistId")]
    [BsonRepresentation(BsonType.ObjectId)]
    /// <summary>
    /// Gets or sets the artist ID for the album (references Artist).
    /// </summary>
    public required string? ArtistId { get; set; } // references Artist
    
    [BsonElement("artistName")]
    /// <summary>
    /// Gets or sets the artist name (denormalized for easy access).
    /// </summary>
    public string? ArtistName { get; set; } // denormalized for easy access

    [BsonElement("releaseYear")]
    /// <summary>
    /// Gets or sets the release year of the album.
    /// </summary>
    public int? ReleaseYear { get; set; }

    [BsonElement("genreIds")]
    /// <summary>
    /// Gets or sets the list of genre IDs associated with the album (references Genre).
    /// </summary>
    public List<ObjectId> GenreIds { get; set; } = []; // references Genre

    [BsonElement("coverImage")]
    /// <summary>
    /// Gets or sets the cover image URL of the album.
    /// </summary>
    public string? CoverImage { get; set; }

    [BsonElement("recordLabel")]
    /// <summary>
    /// Gets or sets the record label of the album.
    /// </summary>
    public string? RecordLabel { get; set; }

    [BsonElement("createdAt")]
    /// <summary>
    /// Gets or sets the creation date of the album record.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    /// <summary>
    /// Gets or sets the last update date of the album record.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    [BsonElement("isActive")]
    /// <summary>
    /// Gets or sets a value indicating whether the album is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
