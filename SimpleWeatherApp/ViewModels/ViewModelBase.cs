using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace SimpleWeatherApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(Expression<Func<object>> expression)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(GetPropertyName(expression)));
            }
        }

        protected string GetPropertyName(Expression<Func<object>> expression)
        {
            var memberEx = expression.Body as MemberExpression;
            return memberEx != null ? memberEx.Member.Name : null;
        }
    }
}
