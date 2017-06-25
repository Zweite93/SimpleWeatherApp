using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using SimpleWeatherApp;
using SimpleWeatherApp.Models;
using SimpleWeatherApp.ViewModels;
using UnitTesting.Properties;

namespace UnitTesting.ViewModelsTesting
{
    /// <summary>
    /// Summary description for ForecastControlViewModelTest
    /// </summary>
    [TestClass]
    public class ForecastControlViewModelTest
    {
        private readonly City _city;
        public ForecastControlViewModelTest()
        {
            ContainerHelper.Container = new UnityContainer();
            _city = JsonConvert.DeserializeObject<City>(Resources.LondonCurretWeatherJsonResponse);
            _city.ForecastInfo =
                JsonConvert.DeserializeObject<ForecastInfo>(Resources.LondonForecastJsonResponse).Forecast;
        }

        [TestMethod]
        public void HorulyForecastTest()
        {
            var hourluForecastVm = new HourlyForecastControlViewModel(_city.ForecastInfo[0]);

            TestBaseProperties(hourluForecastVm);
            Assert.AreEqual("14:00", hourluForecastVm.Date);
        }

        [TestMethod]
        public void DailyForecastTest()
        {
            var dailyForecast = new List<Forecast>
            {
                _city.ForecastInfo[1],
                _city.ForecastInfo[2]
            };

            var mock = new Mock<IDialogManager>();
            ContainerHelper.Container.RegisterInstance(mock.Object);

            var dailyForecastVm = new DailyForecastControlViewModel(_city.ForecastInfo[0], dailyForecast);
            TestBaseProperties(dailyForecastVm);

            Assert.AreEqual("16.02.2017", dailyForecastVm.Date);

        }

        private void TestBaseProperties(BaseForecastControlViewModel baseForecastControlView)
        {
            Assert.AreEqual(286.67, baseForecastControlView.Main.Temperature);
            Assert.AreEqual(286.67, baseForecastControlView.Main.MaxTemperature);
            Assert.AreEqual(281.556, baseForecastControlView.Main.MinTemperature);
            Assert.AreEqual(75, baseForecastControlView.Main.Humidity);

            Assert.AreEqual("Clear", baseForecastControlView.Weather.Main);
            Assert.AreEqual("clear sky", baseForecastControlView.Weather.Description);
            Assert.AreEqual("01d", baseForecastControlView.Weather.Icon);
        }
    }
}
