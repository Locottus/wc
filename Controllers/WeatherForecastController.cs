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

        private MongoWC mongoDrv = new MongoWC();
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("weather")]
        public async Task<WeatherC> GetWeather(string latitude, string longitude)
        {
            //find xy
            WeatherC exists = await mongoDrv.findByCoordinates(latitude, longitude);

            if (exists.Id.Length > 0)
            {
                return exists;
            }
            else
            {
                //get from service
                //await mongoDrv.writeToMongo(wc);
            }
            return exists;
        }

        [HttpGet]
        [Route("weather-bonus")]
        public async Task<WeatherC> GetWeatherBonus(string city)
        {
            //find city
            WeatherC exists = await mongoDrv.findByCity(city);

            if (exists.Id.Length > 0)
            {
                return exists;
            }
            else
            {
                //get from service
                //await mongoDrv.writeToMongo(wc);
            }
            return exists;
        }


    }
}