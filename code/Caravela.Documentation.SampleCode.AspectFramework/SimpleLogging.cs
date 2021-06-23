
using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.SimpleLogging
{
    internal class TargetCode
    {
        [SimpleLog]
        public void Method1()
        {
            Console.WriteLine("Hello, world.");
        }
    }
}

