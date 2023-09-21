using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace wc1.Models
{
    /// <summary>
    /// Weather model to return to user
    /// </summary>
    public class WeatherC
    {
        /// <summary>
        /// id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        //public string City { get; set; } = "";
        /// <summary>
        /// latitude
        /// </summary>
        public string Latitude { get; set; } = "";

        /// <summary>
        /// longitude
        /// </summary>
        public string Longitude { get; set; } = "";

        /// <summary>
        /// temperature
        /// </summary>
        public string Tempeture { get; set; } = "";

        /// <summary>
        /// wind direction
        /// </summary>
        public string WindDirection { get; set; } = "";

        /// <summary>
        /// wind speed
        /// </summary>
        public string WindSpeed { get; set; } = "";

        /// <summary>
        /// sunrise
        /// </summary>
        public string Sunrise { get; set; } ="";

        /// <summary>
        /// date time
        /// </summary>
        public string DateTime { get; set; } = "";

    }
}
