using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas;

/// <summary>
/// Represents an artist in the music library.
/// </summary>
public class Artist
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    /// <summary>
    /// Gets or sets the unique identifier for the artist.
    /// </summary>
    public string? Id { get; set; }

    [BsonElement("name")]
    /// <summary>
    /// Gets or sets the name of the artist.
    /// </summary>
    public required string Name { get; set; }

    [BsonElement("bio")]
    /// <summary>
    /// Gets or sets the biography of the artist.
    /// </summary>
    public string? Bio { get; set; }

    [BsonElement("origin")]
    /// <summary>
    /// Gets or sets the origin of the artist.
    /// </summary>
    public string? Origin { get; set; }

    [BsonElement("image")]
    /// <summary>
    /// Gets or sets the image URL of the artist.
    /// </summary>
    public string? Image { get; set; }

    [BsonElement("birthDate")]
    /// <summary>
    /// Gets or sets the birth date of the artist.
    /// </summary>
    public DateOnly? BirthDay { get; set; }

    [BsonElement("genreIds")]
    /// <summary>
    /// Gets or sets the list of genre IDs associated with the artist.
    /// </summary>
    public List<ObjectId> GenreIds { get; set; } = [];

    [BsonElement("createdAt")]
    /// <summary>
    /// Gets or sets the creation date of the artist record.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    /// <summary>
    /// Gets or sets the last update date of the artist record.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    [BsonElement("isActive")]
    /// <summary>
    /// Gets or sets a value indicating whether the artist is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
