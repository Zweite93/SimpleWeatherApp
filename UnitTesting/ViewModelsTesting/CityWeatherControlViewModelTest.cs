using System.Windows;
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
    /// Summary description for CityWeatherControlViewModelTest
    /// </summary>
    [TestClass]
    public class CityWeatherControlViewModelTest
    {
        private readonly City _city;

        public CityWeatherControlViewModelTest()
        {
            ContainerHelper.Container = new UnityContainer();
            _city = JsonConvert.DeserializeObject<City>(Resources.LondonCurretWeatherJsonResponse);
            _city.ForecastInfo =
                JsonConvert.DeserializeObject<ForecastInfo>(Resources.LondonForecastJsonResponse).Forecast;

            var mainWindowVm = Mock.Of<IMainWindowViewModel>();
            var hourlyForecastControlVm = Mock.Of<IHourlyForecastControlViewModel>();
            var dailyForecastControlVm = Mock.Of<IDailyForecastControlViewModel>();
            ContainerHelper.Container.RegisterInstance(mainWindowVm);
            ContainerHelper.Container.RegisterInstance(hourlyForecastControlVm);
            ContainerHelper.Container.RegisterInstance(dailyForecastControlVm);
        }

        [TestMethod]
        public void CityWeatherControlViewModel_InstanceTest()
        {
            Assert.IsNotNull(GetCityWeatherControlViewModel());
        }

        [TestMethod]
        public void CityWeatherControlViewModel_CityInfoCaptionTest()
        {
            var cityWeatherControlVm = GetCityWeatherControlViewModel();

            Assert.AreEqual("London", cityWeatherControlVm.CityName);
            Assert.AreEqual("GB", cityWeatherControlVm.CountryCode);
            Assert.AreEqual("30.01.2017", cityWeatherControlVm.CurretDate);
            Assert.AreEqual("17:20", cityWeatherControlVm.LastUpdate);

            Assert.AreEqual("Drizzle", cityWeatherControlVm.Weather.Main);
            Assert.AreEqual("light intensity drizzle", cityWeatherControlVm.Weather.Description);
            Assert.AreEqual("09d", cityWeatherControlVm.Weather.Icon);

            Assert.AreEqual("http://openweathermap.org/img/w/09d.png", cityWeatherControlVm.WeatherIcon);

            Assert.AreEqual(81, cityWeatherControlVm.WeatherMainInfo.Humidity);
            Assert.AreEqual(281.15, cityWeatherControlVm.WeatherMainInfo.MaxTemperature);
            Assert.AreEqual(279.15, cityWeatherControlVm.WeatherMainInfo.MinTemperature);
            Assert.AreEqual(280.32, cityWeatherControlVm.WeatherMainInfo.Temperature);
        }

        [TestMethod]
        public void CityWeatherControlViewModel_ChangeForecastTypeTest()
        {
            var cityWeatherControlVm = GetCityWeatherControlViewModel();

            Assert.AreEqual(Visibility.Visible, cityWeatherControlVm.CurretDayForecastVisibility);
            Assert.AreEqual(Visibility.Collapsed, cityWeatherControlVm.DailyForecastVisibility);
            Assert.AreEqual("Show Daily Forecast", cityWeatherControlVm.ForecastTypeButtonCaption);

            cityWeatherControlVm.ChangeForecastTypeCommand.Execute(null);

            Assert.AreEqual(Visibility.Collapsed, cityWeatherControlVm.CurretDayForecastVisibility);
            Assert.AreEqual(Visibility.Visible, cityWeatherControlVm.DailyForecastVisibility);
            Assert.AreEqual("Show Curret Forecas", cityWeatherControlVm.ForecastTypeButtonCaption);
        }

        private CityWeatherControlViewModel GetCityWeatherControlViewModel()
        {
            var mainWindowVm = Mock.Of<IMainWindowViewModel>();
            return new CityWeatherControlViewModel(_city, mainWindowVm);
        }
    }
}
