using System;
using Caravela.Documentation.SampleCode.AspectFramework.Ordering;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.Ordering
{
    [Aspect1, Aspect2]
    internal class TargetCode
    {
        public void SourceMethod()
        {
            Console.WriteLine("Executing Aspect1. Methods present before applying Aspect1: SourceMethod, Method2");
            Console.WriteLine("Executing Aspect2. Methods present before applying Aspect2: SourceMethod");
            Console.WriteLine("Method defined in source code.");
            goto __aspect_return_1;
        __aspect_return_1:
            return;
        }


        public void Method2()
        {
            Console.WriteLine("Executing Aspect1. Methods present before applying Aspect1: SourceMethod, Method2");
            Console.WriteLine("Method introduced by Aspect2.");
            return;
        }

        public void Method1()
        {
            Console.WriteLine("Method introduced by Aspect1.");
        }
    }
}