using SimpleWeatherApp.Views;

namespace SimpleWeatherApp
{
    public class DialogManager : IDialogManager
    {
        public void ShowHourlyForecastDialog(object dataContext, string dateCaption)
        {
            var dialog = ContainerHelper.Resolve<IHourlyForecastForSelectedDayView>();
            dialog.DataContext = dataContext;
            dialog.Title = string.Format("Forecast for {0}", dateCaption);
            dialog.ShowDialog();
        }
    }

    public interface IDialogManager
    {
        void ShowHourlyForecastDialog(object dataContext, string dateCaption);
    }
}
