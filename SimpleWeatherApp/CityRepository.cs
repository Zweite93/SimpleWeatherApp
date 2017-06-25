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

        public ForecastInfo GetCityForecastByName(string cityName)
        {
            return OpenWeather.GetCityForecast(cityName);
        }
    }

    public interface ICityRepository
    {
        City GetCityByName(string cityName);
        ForecastInfo GetCityForecastByName(string cityName);
    }
}
