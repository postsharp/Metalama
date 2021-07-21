using System;
using Caravela.Documentation.SampleCode.AspectFramework.Ordering;
using Caravela.Framework.Aspects;

[assembly: AspectOrder(typeof(Aspect1), typeof(Aspect2))]

namespace Caravela.Documentation.SampleCode.AspectFramework.Ordering
{
    [Aspect1, Aspect2]
    internal class TargetCode
    {
        public void SourceMethod()
        {
            Console.WriteLine("Method defined in source code.");
        }
    }
}