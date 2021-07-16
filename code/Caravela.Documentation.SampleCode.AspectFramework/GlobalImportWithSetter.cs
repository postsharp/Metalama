using System;
using System.Collections.Generic;

namespace Caravela.Documentation.SampleCode.AspectFramework.GlobalImportWithSetter
{
    class TargetCode
    {
        [Import]
        IFormatProvider _formatProvider { get; set; }
    }

    class ServiceLocator : IServiceProvider
    {

        private static readonly ServiceLocator _instance = new();
        private readonly Dictionary<Type, object> _services = new();

        public static IServiceProvider ServiceProvider => _instance;


        object IServiceProvider.GetService(Type serviceType)
        {
            this._services.TryGetValue(serviceType, out var value);
            return value;
        }

        public static void AddService<T>(T service) => _instance._services[typeof(T)] = service;
    }

}
