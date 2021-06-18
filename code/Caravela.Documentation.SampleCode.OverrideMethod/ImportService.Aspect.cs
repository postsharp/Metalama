using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;
using Caravela.Framework.Diagnostics;

namespace Caravela.Documentation.SampleCode.OverrideMethod.ImportService
{
    class ImportServiceAspect : OverrideFieldOrPropertyAspect
    {

        static readonly DiagnosticDefinition<INamedType> _serviceProviderFieldMissing = new(
             "MY001",
             Severity.Error,
             "The 'ImportServiceAspect' aspects requires the type '{0}' to have a field named '_serviceProvider' and " +
            " of type 'IServiceProvider'.");

        static readonly DiagnosticDefinition<(IField, IType)> _serviceProviderFieldTypeMismatch = new(
            "MY002",
            Severity.Error,
            "The type of field '{0}' must be 'IServiceProvider', but it is '{1}.");


        static readonly SuppressionDefinition _suppressFieldIsNeverUsed = new("CS0169");

        public override void BuildAspect(IAspectBuilder<IFieldOrProperty> builder)
        {
            // Get the field _serviceProvider and check its type.
            var serviceProviderField = builder.TargetDeclaration.DeclaringType.Fields.OfName("_serviceProvider").SingleOrDefault();

            if (serviceProviderField == null)
            {
                builder.Diagnostics.Report(_serviceProviderFieldMissing, builder.TargetDeclaration.DeclaringType);
                return;
            }
            else if (!serviceProviderField.Type.Is(typeof(IServiceProvider)))
            {
                builder.Diagnostics.Report(_serviceProviderFieldTypeMismatch, (serviceProviderField, serviceProviderField.Type));
                return;
            }

            // Provide the advice.
            base.BuildAspect(builder);

            // Suppress the diagnostic.
            builder.Diagnostics.Suppress(serviceProviderField, _suppressFieldIsNeverUsed);
        }

        public override dynamic OverrideProperty
        {
            get
            {
                return meta.This._serviceProvider.GetService(meta.FieldOrProperty.Type.ToType());
            }

            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
