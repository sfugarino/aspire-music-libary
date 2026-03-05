using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MusicLibrary.ApiService.Schemas;

/// <summary>
/// Represents a genre in the music library.
/// </summary>
public class Genre
{

    /// <summary>
    /// Gets or sets the unique identifier for the genre.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    /// <summary>
    /// Gets or sets the name of the genre.
    /// </summary>
    [BsonElement("name")]
    public required string Name { get; set; }


    /// <summary>
    /// Gets or sets the description of the genre.
    /// </summary>
    [BsonElement("description")]
    public string? Description { get; set; }


    /// <summary>
    /// Gets or sets the creation date of the genre record.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }


    /// <summary>
    /// Gets or sets the last update date of the genre record.
    /// </summary>
    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether the genre is active.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
