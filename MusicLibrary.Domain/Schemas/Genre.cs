using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MusicLibrary.Domain.Schemas;

/// <summary>
/// Represents a genre in the music library.
/// </summary>
public class Genre : Schema
{
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

}
