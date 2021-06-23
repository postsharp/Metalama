using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.CompileTimeForEach
{
    internal class TargetCode
    {
        [CompileTimeForEach]
        private void Method(int a, string b)
        {
            Console.WriteLine("p = " + a);
            Console.WriteLine("p = " + b);
            Console.WriteLine("Hello, world.");
            return;
        }
    }
}