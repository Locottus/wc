using Microsoft.AspNetCore.Mvc;
using System.Net;
using wc1.Models;
using wc1.Mongo;

namespace wc1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /*private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };*/
        
        private MongoWC mongoDrv = new MongoWC();
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("weather")]
        public async  Task<HttpResponseMessage> GetWeather(double latitude, double longitude)
        {
            //find xy
            WeatherC wc = new WeatherC();
            wc.Latitude = latitude;
            wc.Longitude = longitude;
            wc.DateTime = DateTime.Now.ToString();
            wc.City = "";
            wc.WindDirection = "0";
            wc.WindSpeed = "0";
            wc.Tempeture = "0";
            wc.Sunrise = "6:00am";
            if ( await mongoDrv.writeToMongo(wc))
                return new HttpResponseMessage(HttpStatusCode.OK); 
            else return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("weather-bonus")]
        public async Task<HttpResponseMessage> GetWeatherBonus(string city)
        {
            //find city

            WeatherC wc = new WeatherC();
            wc.Latitude = 0;
            wc.Longitude = 0;
            wc.DateTime = DateTime.Now.ToString();
            wc.City = city;
            wc.WindDirection = "0";
            wc.WindSpeed = "0";
            wc.Tempeture = "0";
            wc.Sunrise = "6:00am";
            if (await mongoDrv.writeToMongo(wc))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else return new HttpResponseMessage(HttpStatusCode.BadRequest);

        }


    }
}