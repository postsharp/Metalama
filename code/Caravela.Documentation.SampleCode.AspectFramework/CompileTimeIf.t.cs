using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.CompileTimeIf
{
    internal class TargetCode
    {
        [CompileTimeIf]
        public void InstanceMethod()
        {
            Console.WriteLine($"Invoking Caravela.Documentation.SampleCode.AspectFramework.CompileTimeIf.TargetCode.InstanceMethod() on instance {base.ToString()}.");
            Console.WriteLine("InstanceMethod");
            return;
        }

        [CompileTimeIf]
        public static void StaticMethod()
        {
            Console.WriteLine($"Invoking Caravela.Documentation.SampleCode.AspectFramework.CompileTimeIf.TargetCode.StaticMethod()");
            Console.WriteLine("StaticMethod");
            return;
        }
    }
}
