using System;
using System.Net;
using Newtonsoft.Json;
using SimpleWeatherApp.Models;

namespace SimpleWeatherApp.OpenWeatherApi
{
    public class OpenWeather
    {
        private const string AppId = "27143ce6ada508dd2518e4c453789964";
        private const string ApiUrl = @"http://api.openweathermap.org/data/2.5";
        private const string ForecastUri = "/forecast?q=";
        private const string CurretWeatherUri = "/weather?q=";
        private const string Metric = "&units=metric";

        public static City GetCity(string cityName)
        {
            using (var client = new WebClient())
            {
                var url = string.Format("{0}{1}{2}{3}&appid={4}", ApiUrl, CurretWeatherUri, cityName, Metric, AppId);

                try
                {
                    var response = client.DownloadString(url);
                    return JsonConvert.DeserializeObject<City>(response);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static ForecastInfo GetCityForecast(string cityName)
        {
            using (var client = new WebClientExtended())
            {
                var url = string.Format("{0}{1}{2}{3}&appid={4}", ApiUrl, ForecastUri, cityName, Metric, AppId);

                try
                {
                    var response = client.DownloadString(url);
                    return JsonConvert.DeserializeObject<ForecastInfo>(response);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        private class WebClientExtended : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest request = base.GetWebRequest(uri);
                if (request != null)
                    request.Timeout = 5000;
                return request;
            }
        }
    }
}
