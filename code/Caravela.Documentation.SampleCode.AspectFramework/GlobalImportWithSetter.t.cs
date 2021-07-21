using System;
using System.Collections.Generic;
using Caravela.Compiler;

namespace Caravela.Documentation.SampleCode.AspectFramework.GlobalImportWithSetter
{
    class TargetCode
    {


        private IFormatProvider __formatProvider1;
        [Import]
        IFormatProvider _formatProvider
        {
            get
            {
                var service = ___formatProvider__OriginalImpl;
                if (service == null)
                {
                    service = (IFormatProvider)ServiceLocator.ServiceProvider.GetService(Type.GetTypeFromHandle(Intrinsics.GetRuntimeTypeHandle("T:System.IFormatProvider")));
                    this.___formatProvider__OriginalImpl = service;
                }

                return service;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        private IFormatProvider ___formatProvider__OriginalImpl
        {
            get
            {
                return this.__formatProvider1;
            }

            set
            {
                this.__formatProvider1 = value;
            }
        }
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
