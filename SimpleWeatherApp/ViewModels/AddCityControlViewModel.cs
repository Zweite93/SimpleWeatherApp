using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Unity;

namespace SimpleWeatherApp.ViewModels
{
    public class AddCityControlViewModel : ViewModelBase, IAddCityControlViewModel
    {
        private readonly IMainWindowViewModel _mainWindowViewModel;

        public AddCityControlViewModel(IMainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public string CityName { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(AddCommandExecute, AddCommandCanExecute);
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new CommandHandler(CancelCommandExecute);
            }
        }

        private void AddCommandExecute()
        {
            var cityRepository = ContainerHelper.Container.Resolve<ICityRepository>();
            var cityInstance = cityRepository.GetCityByName(CityName);


            if (cityInstance == null)
            {
                MessageBox.Show("Incorect City", "Error", MessageBoxButton.OK);
                return;
            }

            cityInstance.ForecastInfo = cityRepository.GetCityForecastByName(CityName).Forecast;

            if (cityInstance.ForecastInfo == null)
            {
                MessageBox.Show("Incorect City", "Error", MessageBoxButton.OK);
                return;
            }

            var cityWeatherControlViewModel = ContainerHelper.Resolve<ICityWeatherControlViewModel>(new
            {
                city = cityInstance,
                mainWindowViewModel = _mainWindowViewModel
            });

            _mainWindowViewModel.ViewModels.Add(cityWeatherControlViewModel as ViewModelBase);
            _mainWindowViewModel.ViewModels.Remove(this);
            _mainWindowViewModel.AddButtonVisibility = Visibility.Visible;
        }

        private bool AddCommandCanExecute()
        {
            return !string.IsNullOrEmpty(CityName);
        }

        private void CancelCommandExecute()
        {
            _mainWindowViewModel.ViewModels.Remove(this);
            _mainWindowViewModel.AddButtonVisibility = Visibility.Visible;
        }
    }

    public interface IAddCityControlViewModel
    {
        ICommand AddCommand { get; }
        ICommand CancelCommand { get; }
        string CityName { get; set; }
    }
}
