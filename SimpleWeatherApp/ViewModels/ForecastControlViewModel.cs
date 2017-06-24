using System;
using System.Collections.Generic;
using System.Windows.Input;
using SimpleWeatherApp.Models;

namespace SimpleWeatherApp.ViewModels
{
    public abstract class BaseForecastControlViewModel
    {
        private readonly Forecast _forecast;

        protected BaseForecastControlViewModel(Forecast forecast)
        {
            _forecast = forecast;
        }

        public Main Main
        {
            get { return _forecast.Main; }
        }

        public Weather Weather
        {
            get { return _forecast.Weather[0]; }
        }

        public Sys Sys
        {
            get { return _forecast.Sys; }
        }

        public string WeatherIcon
        {
            get { return "http://openweathermap.org/img/w/" + Weather.Icon + ".png"; }
        }

        public abstract string Date { get; }

        protected DateTime DateTime
        {
            get { return _forecast.Date.ToLocalTime(); }
        }
    }

    public class DailyForecastControlViewModel : BaseForecastControlViewModel, IDailyForecastControlViewModel
    {
        private readonly List<Forecast> _dailyForecast;
        private readonly IDialogManager _dialogManager;

        public DailyForecastControlViewModel(Forecast forecast, List<Forecast> dailyForecst)
            : base(forecast)
        {
            _dailyForecast = dailyForecst;
            _dialogManager = ContainerHelper.Resolve<IDialogManager>();
        }

        public ICommand ShowForecastForSelectedDayCommand
        {
            get
            {
                return new CommandHandler(ShowForecastForSelectedDayCommandExecute);
            }
        }

        public override string Date
        {
            get { return DateTime.ToShortDateString(); }
        }

        private void ShowForecastForSelectedDayCommandExecute()
        {
            var dataContext = ContainerHelper.Resolve<IHourlyForecastForSelectedDayViewModel>();
            _dailyForecast.ForEach(r =>
                dataContext.HourlyForecast.Add(
                    ContainerHelper.Resolve<IHourlyForecastControlViewModel>(new { forecast = r })));
            _dialogManager.ShowHourlyForecastDialog(dataContext, Date);
        }
    }

    public class HourlyForecastControlViewModel : BaseForecastControlViewModel, IHourlyForecastControlViewModel
    {
        public HourlyForecastControlViewModel(Forecast forecast)
            : base(forecast)
        {
        }

        public override string Date
        {
            get { return DateTime.ToShortTimeString(); }
        }
    }

    public interface IDailyForecastControlViewModel
    {
        ICommand ShowForecastForSelectedDayCommand { get; }
    }

    public interface IHourlyForecastControlViewModel
    {
    }
}
