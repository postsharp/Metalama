using System;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.CompileTimeIf
{
    internal class CompileTimeIfAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            if (meta.Method.IsStatic)
            {
                Console.WriteLine($"Invoking {meta.Method.ToDisplayString()}");
            }
            else
            {
                Console.WriteLine($"Invoking {meta.Method.ToDisplayString()} on instance {meta.This.ToString()}.");
            }

            return meta.Proceed();
        }
    }
}
