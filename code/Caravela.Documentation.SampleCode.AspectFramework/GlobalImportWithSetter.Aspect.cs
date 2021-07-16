using System;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.GlobalImportWithSetter
{
    internal class ImportAttribute : OverrideFieldOrPropertyAspect
    {
        public override dynamic OverrideProperty
        {
            get
            {
                // Gets the current value of the field or property.
                var service = meta.Proceed();

                if (service == null)
                {
                    // Call the service provider.
                    service =
                         meta.Cast(meta.FieldOrProperty.Type,
                            ServiceLocator.ServiceProvider.GetService(meta.Property.Type.ToType()));

                    // Set the field or property to the new value.
                    // Bug 28881: this will call the property setter instead of setting the backing field.
                    meta.FieldOrProperty.Value = service;
                }

                return service;
            }

            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
