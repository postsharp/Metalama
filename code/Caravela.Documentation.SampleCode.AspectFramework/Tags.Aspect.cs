using System;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.Tags
{
    class TagsAspect : Attribute, IAspect<IMethod>
    {
        public void BuildAspect( IAspectBuilder<IMethod> builder )
        {
            builder.AdviceFactory.OverrideMethod(
                builder.TargetDeclaration, 
                nameof(OverrideMethod), 
                tags: new() { ["ParameterCount"] = builder.TargetDeclaration.Parameters.Count });
        }

        [Template]
        private dynamic? OverrideMethod()
        {
            Console.WriteLine($"This method has {meta.Tags["ParameterCount"]} parameters.");
            return meta.Proceed();
        }
    }
}
