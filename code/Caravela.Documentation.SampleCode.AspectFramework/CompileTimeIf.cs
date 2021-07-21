using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.CompileTimeIf
{
    internal class TargetCode
    {
        [CompileTimeIf]
        public void InstanceMethod()
        {
            Console.WriteLine("InstanceMethod");
        }

        [CompileTimeIf]
        public static void StaticMethod()
        {
            Console.WriteLine("StaticMethod");
        }
    }
}
