using System;
using System.Linq;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.CompileTimeForEach
{
    internal class CompileTimeForEachAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            foreach (var p in meta.Parameters.Where(p => p.RefKind != RefKind.Out))
            {
                Console.WriteLine("p = " + p.Value);
            }

            return meta.Proceed();
        }
    }
}
