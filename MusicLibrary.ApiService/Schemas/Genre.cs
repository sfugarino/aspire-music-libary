using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MusicLibrary.ApiService.Schemas;

/// <summary>
/// Represents a genre in the music library.
/// </summary>
public class Genre
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    /// <summary>
    /// Gets or sets the unique identifier for the genre.
    /// </summary>
    public string? Id { get; set; }

    [BsonElement("name")]
    /// <summary>
    /// Gets or sets the name of the genre.
    /// </summary>
    public required string Name { get; set; }

    [BsonElement("description")]
    /// <summary>
    /// Gets or sets the description of the genre.
    /// </summary>
    public string? Description { get; set; }

    [BsonElement("createdAt")]
    /// <summary>
    /// Gets or sets the creation date of the genre record.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    /// <summary>
    /// Gets or sets the last update date of the genre record.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    [BsonElement("isActive")]
    /// <summary>
    /// Gets or sets a value indicating whether the genre is active.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
