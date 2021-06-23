using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.SimpleLogging
{
    internal class TargetCode
    {
        [SimpleLog]
        public void Method1()
        {
            Console.WriteLine($"Entering Caravela.Documentation.SampleCode.AspectFramework.SimpleLogging.TargetCode.Method1()");
            try
            {
                Console.WriteLine("Hello, world.");
                return;
            }
            finally
            {
                Console.WriteLine($"Leaving Caravela.Documentation.SampleCode.AspectFramework.SimpleLogging.TargetCode.Method1()");
            }
        }
    }
}