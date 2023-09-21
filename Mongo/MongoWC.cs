using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using wc1.Models;

namespace wc1.Mongo
{
    public class MongoWC
    {
        //mongodb://localhost:27017

        private string connectionString = "mongodb://localhost:27017";
        private string databaseName = "local";
        private string collectionName = "startup_log";
        //private int @string = 0;

        public async Task<bool> writeMongoAsync( WeatherC wc)
        {
            try
            {
                Console.WriteLine("Empezamos app");
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



    }
}
