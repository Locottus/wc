using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace wc1.Models
{
    public class WeatherC
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

    }
}
