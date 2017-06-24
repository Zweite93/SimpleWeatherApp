using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.ObjectBuilder2;
using SimpleWeatherApp.Models;

namespace SimpleWeatherApp.ViewModels
{
    public class CityWeatherControlViewModel : ViewModelBase, ICityWeatherControlViewModel
    {
        private readonly City _city;
        private readonly IMainWindowViewModel _mainWindowViewModel;
        private readonly DateTime _lastUpdate;
        private const int HourToDisplay = 12;
        private const string ShowCurretForecastCaption = "Show Curret Forecas";
        private const string ShowDailyForecastCaption = "Show Daily Forecast";
        private Visibility _curretDayForecastVisibility;
        private Visibility _dailyForecastVisibility;

        private bool _forecastTypeIsDaily;

        public CityWeatherControlViewModel(City city, IMainWindowViewModel mainWindowViewModel)
        {
            _city = city;
            _mainWindowViewModel = mainWindowViewModel;
            _lastUpdate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            _lastUpdate = _lastUpdate.AddSeconds(_city.Date);
            DailyForecastVisibility = Visibility.Collapsed;
            InitializeCurretDayForecast();
        }

        public ObservableCollection<IHourlyForecastControlViewModel> CurretDayForecast { get; set; }

        public ObservableCollection<IDailyForecastControlViewModel> DailyForecast { get; set; }

        public string CityName
        {
            get { return _city.Name; }
        }

        public string CountryCode
        {
            get { return _city.Sys.Country; }
        }

        public Weather Weather
        {
            get { return _city.CurretWeather[0]; }
        }

        public Main WeatherMainInfo
        {
            get { return _city.Main; }
        }

        public string WeatherIcon
        {
            get { return "http://openweathermap.org/img/w/" + Weather.Icon + ".png"; }
        }

        public string CurretDate
        {
            get
            {
                return _lastUpdate.ToLocalTime().ToShortDateString();
            }
        }

        public string LastUpdate
        {
            get { return _lastUpdate.ToLocalTime().ToShortTimeString(); }
        }

        public string ForecastTypeButtonCaption
        {
            get { return _forecastTypeIsDaily ? ShowCurretForecastCaption : ShowDailyForecastCaption; }
        }

        public Visibility CurretDayForecastVisibility
        {
            get { return _curretDayForecastVisibility; }
            set
            {
                if (value != _curretDayForecastVisibility)
                {
                    _curretDayForecastVisibility = value;
                    OnPropertyChanged(() => CurretDayForecastVisibility);
                }
            }
        }

        public Visibility DailyForecastVisibility
        {
            get { return _dailyForecastVisibility; }
            set
            {
                if (value != _dailyForecastVisibility)
                {
                    _dailyForecastVisibility = value;
                    OnPropertyChanged(() => DailyForecastVisibility);
                }
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new CommandHandler(RemoveCommandExecute);
            }
        }

        public ICommand ChangeForecastTypeCommand
        {
            get
            {
                return new CommandHandler(ChangeForecastTypeCommandExecute);
            }
        }

        private void RemoveCommandExecute()
        {
            _mainWindowViewModel.ViewModels.Remove(this);
        }

        private void ChangeForecastTypeCommandExecute()
        {
            _forecastTypeIsDaily = !_forecastTypeIsDaily;
            OnPropertyChanged(() => ForecastTypeButtonCaption);

            if (!_forecastTypeIsDaily)
            {
                CurretDayForecastVisibility = Visibility.Visible;
                DailyForecastVisibility = Visibility.Collapsed;
                return;
            }

            if (DailyForecast == null)
                InitializeDailyForecast();

            CurretDayForecastVisibility = Visibility.Collapsed;
            DailyForecastVisibility = Visibility.Visible;
        }

        private void InitializeCurretDayForecast()
        {
            CurretDayForecast = new ObservableCollection<IHourlyForecastControlViewModel>();
            var t = DateTime.Now.ToUniversalTime().DayOfWeek;
            _city.Forecast.Forecast.Where(r => r.Date.DayOfWeek == DateTime.Now.DayOfWeek)
                .ForEach(p =>
                    CurretDayForecast.Add(
                        ContainerHelper.Resolve<IHourlyForecastControlViewModel>(new { forecast = p }))
                );
        }

        private void InitializeDailyForecast()
        {
            DailyForecast = new ObservableCollection<IDailyForecastControlViewModel>();
            var dailyForecst = new List<Forecast>();

            foreach (
                var day in
                _city.Forecast.Forecast.Where(r => r.Date.Date != DateTime.Now.Date).GroupBy(r => r.Date.Date))
            {
                day.ForEach(weather => dailyForecst.Add(weather));

                DailyForecast.Add(
                    ContainerHelper.Resolve<IDailyForecastControlViewModel>(
                        new
                        {
                            forecast = dailyForecst.First(r => r.Date.Hour == HourToDisplay),
                            dailyForecst = dailyForecst
                        }));

                dailyForecst = new List<Forecast>();
            }
        }
    }

    public interface ICityWeatherControlViewModel
    {
        string CityName { get; }
        string CountryCode { get; }
        string WeatherIcon { get; }
        string CurretDate { get; }
        string LastUpdate { get; }
        Weather Weather { get; }
        Main WeatherMainInfo { get; }
        string ForecastTypeButtonCaption { get; }
        ObservableCollection<IHourlyForecastControlViewModel> CurretDayForecast { get; set; }
        ObservableCollection<IDailyForecastControlViewModel> DailyForecast { get; set; }

    }
}
