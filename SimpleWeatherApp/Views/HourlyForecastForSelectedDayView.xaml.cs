using System.Windows;

namespace SimpleWeatherApp.Views
{
    /// <summary>
    /// Interaction logic for HourlyForecastForSelectedDayView.xaml
    /// </summary>
    public partial class HourlyForecastForSelectedDayView : Window, IHourlyForecastForSelectedDayView
    {
        public HourlyForecastForSelectedDayView()
        {
            InitializeComponent();
        }
    }

    public interface IHourlyForecastForSelectedDayView
    {
        bool? ShowDialog();
        object DataContext { get; set; }
        string Title { get; set; }
    }
}
