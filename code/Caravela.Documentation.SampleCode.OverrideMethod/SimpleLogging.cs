
using System;

namespace Caravela.Documentation.SampleCode.OverrideMethod.SimpleLogging
{
    class TargetCode
    {
        [SimpleLog]
        public void Method1()
        {
            Console.WriteLine("Hello, world.");
        }
    }
}

