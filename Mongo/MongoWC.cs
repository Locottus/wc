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

        public async Task<bool> findByCoordinates(double latitude, double longitude)
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
            var result = collection.Find(filter).ToList();

            // Itera sobre los resultados encontrados
            foreach (var document in result)
            {
                Console.WriteLine(document.ToString()); 
            }

            if (result.Count > 0)
                return true;
            else
                return false;

        }


        public bool findByCity(string city)
        {
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var filter = Builders<BsonDocument>.Filter.Eq("City", city);
            var result = collection.Find(filter).ToList();

            // Itera sobre los resultados encontrados
            foreach (var document in result)
            {
                Console.WriteLine(document.ToString()); 
            }

            if (result.Count > 0)
                return true;
            else 
                return false;
        }



    }
}
