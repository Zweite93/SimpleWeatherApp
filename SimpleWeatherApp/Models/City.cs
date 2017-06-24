using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleWeatherApp.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }
        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Sys
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    [JsonObject("List")]
    public class Forecast
    {
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("dt_txt")]
        public DateTime Date { get; set; }
    }

    [JsonObject("RootObject")]
    public class CityForecast
    {
        [JsonProperty("list")]
        public List<Forecast> Forecast { get; set; }
    }

    [JsonObject("RootObject")]
    public class City
    {
        [JsonProperty("weather")]
        public List<Weather> CurretWeather { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dt")]
        public int Date { get; set; }
        public CityForecast Forecast { get; set; }
    }
}
