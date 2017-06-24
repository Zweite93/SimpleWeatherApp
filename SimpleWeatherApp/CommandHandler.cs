using System;
using System.Windows.Input;

namespace SimpleWeatherApp
{
    public class CommandHandler : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public CommandHandler(Action action, Func<Boolean> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
