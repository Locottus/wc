
using wc1.Models;
using System.Text.Json;


namespace wc1.WService
{
    public class WSrv
    {

        /// <summary>
        /// gets the weather from the open meteo service 
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>the weather in the desired format</returns>
        /// <exception cref="Exception">if error, it shows excpetion</exception>
        public async Task<WeatherC> GetWeatherByLatitudAndLongitude(string latitude, string longitude)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true&daily=sunrise";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string climate = await response.Content.ReadAsStringAsync();
                    WeatherData fs = JsonSerializer.Deserialize<WeatherData>(climate);
                    WeatherC weatherC = new WeatherC();
                    weatherC.Latitude = fs.latitude.ToString().Trim();
                    weatherC.Longitude = fs.longitude.ToString().Trim();
                    weatherC.DateTime = fs.current_weather.time;
                    weatherC.Tempeture = fs.current_weather.temperature.ToString().Trim();
                    weatherC.Sunrise = fs.daily_units.sunrise.ToString().Trim();
                    weatherC.WindDirection = fs.current_weather.winddirection.ToString().Trim();
                    weatherC.WindSpeed = fs.current_weather.windspeed.ToString().Trim();
                    return weatherC;
                }
                else
                {
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }
        }

    }
}
