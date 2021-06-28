using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;
using static System.Net.Mime.MediaTypeNames;

namespace Caravela.Documentation.SampleCode.AspectFramework.Normalize
{
    class NormalizeAttribute : Attribute, IAspect<IFieldOrProperty>
    {
        public void BuildAspect( IAspectBuilder<IFieldOrProperty> builder )
        {
            builder.AdviceFactory.OverrideFieldOrProperty(builder.TargetDeclaration, nameof(this.OverrideProperty));
        }

        [Template]
        string OverrideProperty
        {
            set
            {

                // Bug #28802: Expression-bodied setter templates are ignored.
                // Bug #28803: Setting a value through meta.FieldOrProperty.Value generates access to the current layer instead of the next one.

                meta.FieldOrProperty.Value = value?.Trim().ToLowerInvariant();
            }
        }
    }
}
