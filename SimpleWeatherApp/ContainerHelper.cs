using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace SimpleWeatherApp
{
    public static class ContainerHelper
    {
        public static UnityContainer Container { get; set; }

        public static T Resolve<T>(object parameterOverrides)
        {
            var properties = parameterOverrides
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var overridesArray = properties
                .Select(p => new ParameterOverride(p.Name, p.GetValue(parameterOverrides, null)))
                .Cast<ResolverOverride>()
                .ToArray();

            return Container.Resolve<T>(null, overridesArray);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            Container.RegisterType<TFrom, TTo>();
        }
    }
}
