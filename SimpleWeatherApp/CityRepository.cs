using SimpleWeatherApp.Models;
using SimpleWeatherApp.OpenWeatherApi;

namespace SimpleWeatherApp
{
    public class CityRepository : ICityRepository
    {
        public City GetCityByName(string cityName)
        {
            return OpenWeather.GetCity(cityName);
        }

        public CityForecast GetCityForecastByName(string cityName)
        {
            return OpenWeather.GetCityForecast(cityName);
        }
    }

    public interface ICityRepository
    {
        City GetCityByName(string cityName);
        CityForecast GetCityForecastByName(string cityName);
    }
}
