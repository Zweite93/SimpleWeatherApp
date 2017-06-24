using System.Collections.ObjectModel;

namespace SimpleWeatherApp.ViewModels
{
    public class HourlyForecastForSelectedDayViewModel : ViewModelBase, IHourlyForecastForSelectedDayViewModel
    {
        public ObservableCollection<IHourlyForecastControlViewModel> HourlyForecast
        {
            get;
            set;
        }

        public HourlyForecastForSelectedDayViewModel()
        {
            HourlyForecast = new ObservableCollection<IHourlyForecastControlViewModel>();
        }
    }

    public interface IHourlyForecastForSelectedDayViewModel
    {
        ObservableCollection<IHourlyForecastControlViewModel> HourlyForecast { get; set; }
    }
}
