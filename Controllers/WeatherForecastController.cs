using Microsoft.AspNetCore.Mvc;
using System.Net;
using wc1.Models;
using wc1.Mongo;
using wc1.WService;

namespace wc1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private MongoWC mongoDrv = new MongoWC();
        private WSrv wsrv = new WSrv();
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// service that gets weather from open service and delivers
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>the ofject in the desired format with the data required</returns>
        [HttpGet]
        [Route("weather")]
        public async Task<WeatherC> GetWeather(string latitude, string longitude)
        {
            WeatherC exists = await mongoDrv.findByCoordinates(latitude, longitude);
            if (exists.Id.Length > 0)
            {
                return exists;
            }
            else
            {
                //get from service
                var wc = await wsrv.GetWeatherByLatitudAndLongitude(latitude, longitude);
                await mongoDrv.writeToMongo(wc);
                return wc;
            }            
        }

    }
}