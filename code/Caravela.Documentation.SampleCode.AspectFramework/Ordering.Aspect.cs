using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.Ordering
{
    internal class Aspect1 : Attribute, IAspect<INamedType>
    {
        public void BuildAspect(IAspectBuilder<INamedType> builder)
        {
            foreach (var m in builder.TargetDeclaration.Methods)
            {
                builder.AdviceFactory.OverrideMethod(m, nameof(Override));
            }
        }

        [Introduce]
        public void Method1()
        {
            Console.WriteLine("Method introduced by Aspect1.");
        }

        [Template]
        private dynamic? Override()
        {
            Console.WriteLine("Executing Aspect1. Methods present before applying Aspect1: "
                + string.Join(", ", meta.NamedType.Methods.Select(m => m.Name).ToArray()));

            return meta.Proceed();
        }
    }

    internal class Aspect2 : Attribute, IAspect<INamedType>
    {
        public void BuildAspect(IAspectBuilder<INamedType> builder)
        {
            foreach (var m in builder.TargetDeclaration.Methods)
            {
                builder.AdviceFactory.OverrideMethod(m, nameof(Override));
            }
        }


        [Introduce]
        public void Method2()
        {
            Console.WriteLine("Method introduced by Aspect2.");
        }

        [Template]
        private dynamic? Override()
        {
            Console.WriteLine("Executing Aspect2. Methods present before applying Aspect2: "
                + string.Join(", ", meta.NamedType.Methods.Select(m => m.Name).ToArray()));

            return meta.Proceed();
        }

    }
}
