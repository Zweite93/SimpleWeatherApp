using System.Windows;
using Microsoft.Practices.Unity;
using SimpleWeatherApp.ViewModels;

namespace SimpleWeatherApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeContainer();
            InitializeComponent();
        }

        private void InitializeContainer()
        {
            ContainerHelper.Container = new UnityContainer();
            ContainerHelper.RegisterType<IDialogManager, DialogManager>();
            ContainerHelper.RegisterType<ICityRepository, CityRepository>();
            ContainerHelper.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            ContainerHelper.RegisterType<IAddCityControlViewModel, AddCityControlViewModel>();
            ContainerHelper.RegisterType<ICityWeatherControlViewModel, CityWeatherControlViewModel>();
            ContainerHelper.RegisterType<IDailyForecastControlViewModel, DailyForecastControlViewModel>();
            ContainerHelper.RegisterType<IHourlyForecastControlViewModel, HourlyForecastControlViewModel>();
            ContainerHelper.RegisterType<IHourlyForecastForSelectedDayView, HourlyForecastForSelectedDayView>();
            ContainerHelper.RegisterType<IHourlyForecastForSelectedDayViewModel, HourlyForecastForSelectedDayViewModel>();
        }
    }
}
