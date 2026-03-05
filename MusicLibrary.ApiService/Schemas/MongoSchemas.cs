using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("bio")]
        public string? Bio { get; set; }

        [BsonElement("origin")]
        public string? Origin { get; set; }

        [BsonElement("image")]
        public string? Image { get; set; }

        [BsonElement("birthDate")]
        public DateOnly? BirthDay { get; set; }

        [BsonElement("genreIds")]
        public List<ObjectId> GenreIds { get; set; } = [];

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;
    }

    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("artistId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string? ArtistId { get; set; } // references Artist
        
        [BsonElement("artistName")]
        public string? ArtistName { get; set; } // denormalized for easy access

        [BsonElement("releaseYear")]
        public int? ReleaseYear { get; set; }

        [BsonElement("genreIds")]
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("coverImage")]
        public string? CoverImage { get; set; }

        [BsonElement("recordLabel")]
        public string? RecordLabel { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;
    }

    public class Song
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("albumId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string? AlbumId { get; set; } // references Album

        [BsonElement("artistId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string? ArtistId { get; set; } // references Artist
        
        [BsonElement("artistName")]
        public string? ArtistName { get; set; } // denormalized for easy access

        [BsonElement("duration")]
        public int? Duration { get; set; } // seconds

        [BsonElement("genreIds")]
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("trackNumber")]
        public int? TrackNumber { get; set; }

        [BsonElement("audioFile")]
        public string? AudioFile { get; set; }
        
        [BsonElement("lyrics")]
        public string? Lyrics { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;
    }

    public class Genre
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;
    }

}
