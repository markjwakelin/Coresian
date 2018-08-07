using Coresian.Abstractions;
using Coresian.Factory;
using Coresian.Interfaces.Abstractions;
using Coresian.Interfaces.Factories;
using Coresian.Interfaces.Providers;
using Coresian.Providers;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Coresian
{
    public class Package : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterSingleton<IConverter, Converter>();
            container.RegisterSingleton<ITypeConverter, TypeConverter>();
            container.RegisterSingleton<IInstanceActivator, InstanceActivator>();
            container.RegisterSingleton<IEnvironment, AbstractedEnvironment>();
            container.RegisterSingleton<INewableFactory, NewableFactory>();
            container.RegisterSingleton<IDateTimeProvider, DateTimeProvider>();
            container.RegisterSingleton<IGuidProvider, GuidProvider>();
            container.RegisterSingleton<IStopwatchProvider, StopwatchProvider>();
        }
    }
}
