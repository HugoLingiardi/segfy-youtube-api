using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Segfy.Youtube.Core.Models
{
    public class Channels
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("channelId")]
        public string ChannelId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

    }
}
