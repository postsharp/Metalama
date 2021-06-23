using System;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.Tags
{
    class TagsAspect : Attribute, IAspect<IMethod>
    {
        public void BuildAspect( IAspectBuilder<IMethod> builder )
        {
            var adviceOptions = AdviceOptions.Default.AddTag("ParameterCount", builder.TargetDeclaration.Parameters.Count );
            builder.AdviceFactory.OverrideMethod(builder.TargetDeclaration, nameof(OverrideMethod), adviceOptions);
        }

        [Template]
        private dynamic? OverrideMethod()
        {
            Console.WriteLine($"This method has {meta.Tags["ParameterCount"]} parameters.");
            return meta.Proceed();
        }
    }
}
