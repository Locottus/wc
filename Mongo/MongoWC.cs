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

        public async Task<bool> writeToMongo( WeatherC wc)
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

        public async Task<WeatherC> findByCoordinates(string latitude, string longitude)
        {

            // Establece la conexión al servidor MongoDB
            var client = new MongoClient(connectionString);

            // Obtiene la base de datos y la colección
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // Define el filtro para buscar por los atributos "latitude" y "longitude"
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Latitude", latitude),
                Builders<BsonDocument>.Filter.Eq("Longitude", longitude)
            );

            // Realiza la consulta
            var result = await collection.Find(filter).ToListAsync();

            // Itera sobre los resultados
            WeatherC wc = new WeatherC();

            foreach (var document in result)
            {
                wc.Latitude = latitude;
                wc.Longitude = longitude;
                wc.DateTime = document["DateTime"].AsString;
                wc.City = document["City"].AsString;
                wc.WindDirection = document["WindDirection"].AsString; 
                wc.WindSpeed = document["WindSpeed"].AsString; 
                wc.Tempeture = document["Tempeture"].AsString; 
                wc.Sunrise = document["Sunrise"].AsString;
                var id = document["_id"];
                wc.Id = id.ToString(); 

            }

            return wc;

        }


        public  async Task<WeatherC> findByCity(string city)
        {
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var filter = Builders<BsonDocument>.Filter.Eq("City", city);
            // Realiza la consulta
            var result = await collection.Find(filter).ToListAsync();

            // Itera sobre los resultados
            WeatherC wc = new WeatherC();

            foreach (var document in result)
            {
                wc.Latitude = document["Latitude"].AsString; ;
                wc.Longitude = document["Longitude"].AsString; ;
                wc.DateTime = document["DateTime"].AsString;
                wc.City = city;
                wc.WindDirection = document["WindDirection"].AsString; ;
                wc.WindSpeed = document["WindSpeed"].AsString; ;
                wc.Tempeture = document["Tempeture"].AsString; ;
                wc.Sunrise = document["Sunrise"].AsString; ;
                wc.Id = document["id"].AsString;

            }

            return wc;
        }



    }
}
