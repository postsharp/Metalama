using System;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.SimpleLogging
{
    public class SimpleLogAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            Console.WriteLine($"Entering {meta.Method.ToDisplayString()}");

            try
            {
                return meta.Proceed();
            }
            finally
            {
                Console.WriteLine($"Leaving {meta.Method.ToDisplayString()}");
            }
        }
    }


}
