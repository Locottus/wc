namespace wc1.Models
{
    /// <summary>
    /// the weather model that comes from the open source service.
    /// </summary>
    public class WeatherData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public CurrentWeather current_weather { get; set; }
        public DailyUnits daily_units { get; set; }
        public DailyForecast daily { get; set; }
    }
}
