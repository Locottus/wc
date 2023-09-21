using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.ComponentModel;
using wc1.Models;

namespace wc1.Mongo
{
    public class MongoWC
    {
        //mongodb://localhost:27017

        private string connectionString = "mongodb://localhost:27017";
        private string databaseName = "local";
        private string collectionName = "weather";
        //private int @string = 0;

        /// <summary>
        /// writes new document to mongo db
        /// </summary>
        /// <param name="wc"></param>
        /// <returns>true if no error, false if something happened</returns>
        public async Task<bool> writeToMongo(WeatherC wc)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase(databaseName);
                var collection = db.GetCollection<WeatherC>(collectionName);
                await collection.InsertOneAsync(wc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// finds the document with the coordinates
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>returns the weather in the desired format</returns>
        public async Task<WeatherC> findByCoordinates(string latitude, string longitude)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Latitude", latitude),
                Builders<BsonDocument>.Filter.Eq("Longitude", longitude)
            );

            var result = await collection.Find(filter).ToListAsync();
            WeatherC wc = new WeatherC();
            foreach (var document in result)
            {
                wc.Latitude = latitude;
                wc.Longitude = longitude;
                wc.DateTime = document["DateTime"].AsString;
                wc.WindDirection = document["WindDirection"].AsString;
                wc.WindSpeed = document["WindSpeed"].AsString;
                wc.Tempeture = document["Tempeture"].AsString;
                wc.Sunrise = document["Sunrise"].AsString;
                var id = document["_id"];
                wc.Id = id.ToString();

            }
            return wc;
        }


    }
}
