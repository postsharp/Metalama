using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.ImportService
{
    internal class TargetCode
    {
       // readonly IServiceProvider _serviceProvider;

        [ImportAspect]
        private IFormatProvider FormatProvider { get; }

        public string Format(object? o)
        {
            return ((ICustomFormatter)this.FormatProvider.GetFormat(typeof(ICustomFormatter)))
                .Format(null, o, this.FormatProvider);
        }
    }
}
