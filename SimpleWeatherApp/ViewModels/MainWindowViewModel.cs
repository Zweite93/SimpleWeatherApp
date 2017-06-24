using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SimpleWeatherApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private Visibility _addButtonVisibility;

        public MainWindowViewModel()
        {
            ViewModels = new ObservableCollection<ViewModelBase>();
        }

        public Visibility AddButtonVisibility
        {
            get { return _addButtonVisibility; }
            set
            {
                if (value != _addButtonVisibility)
                {
                    _addButtonVisibility = value;
                    OnPropertyChanged(() => AddButtonVisibility);
                }
            }
        }

        public ObservableCollection<ViewModelBase> ViewModels { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new CommandHandler(AddCommandExecute);
            }
        }

        private void AddCommandExecute()
        {
            AddButtonVisibility = Visibility.Hidden;
            var addCityControlViewModelBase = ContainerHelper.Resolve<IAddCityControlViewModel>(new { mainWindowViewModel = this }) as ViewModelBase;
            ViewModels.Add(addCityControlViewModelBase);
        }

    }

    public interface IMainWindowViewModel
    {
        ICommand AddCommand { get; }
        ObservableCollection<ViewModelBase> ViewModels { get; set; }
        Visibility AddButtonVisibility { get; set; }
    }
}
