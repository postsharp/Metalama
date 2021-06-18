// <aspect>
using System;
using Caravela.Documentation.SampleCode.OverrideMethod.Ordering;
using Caravela.Framework.Aspects;

[assembly: AspectOrder(typeof(Aspect1), typeof(Aspect2))]

namespace Caravela.Documentation.SampleCode.OverrideMethod.Ordering
{
    [Aspect1, Aspect2]
    class TargetCode
    {
        public void SourceMethod() 
        {
            Console.WriteLine("Method defined in source code.");
        }
    }
}