using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace wc1.Models
{
    public class WeatherC
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        public string City { get; set; } = "";

        public string Latitude { get; set; } = "";

        public string Longitude { get; set; } = "";

        public string Tempeture { get; set; } = "";

        public string WindDirection { get; set; } = "";

        public string WindSpeed { get; set; } = "";

        public string Sunrise { get; set; } = "";

        public string DateTime { get; set; } = "";

    }
}
