﻿namespace wc1.Models
{
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int winddirection { get; set; }
        public int weathercode { get; set; }
        public int is_day { get; set; }
        public string time { get; set; }
    }
}
