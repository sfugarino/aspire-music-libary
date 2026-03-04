using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas
{
    public class Artist
    {
        [BsonId]
        public ObjectId? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("bio")]
        public string? Bio { get; set; }

        [BsonElement("country")]
        public string? Country { get; set; }

        [BsonElement("genres")]
        public List<ObjectId> GenreIds { get; set; } = [];

        [BsonElement("albums")]
        public List<ObjectId> AlbumsIds { get; set; } = []; // references Album

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Album
    {
        [BsonId]
        public ObjectId? Id { get; set; }

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("artist")]
        public required ObjectId ArtistId { get; set; } // references Artist

        [BsonElement("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [BsonElement("genres")]
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("tracks")]
        public List<ObjectId> SongIds { get; set; } = []; // references Track

        [BsonElement("coverUrl")]
        public string? CoverUrl { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Song
    {
        [BsonId]
        public ObjectId? Id { get; set; }

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("album")]
        public required ObjectId AlbumId { get; set; } // references Album

        [BsonElement("artist")]
        public required ObjectId ArtistId { get; set; } // references Artist

        [BsonElement("duration")]
        public int? Duration { get; set; } // seconds

        [BsonElement("genres")]
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("trackNumber")]
        public required int TrackNumber { get; set; }

        [BsonElement("audioUrl")]
        public string? AudioUrl { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Genre
    {
        [BsonId]
        public ObjectId? Id { get; set; }

        [BsonElement("name")]
        public required string Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }
    }

}
