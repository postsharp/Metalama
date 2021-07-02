using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.Testing
{
    class SimpleLogTests
    {
        [SimpleLog]
        void MyMethod()
        {
            Console.WriteLine($"Entering Caravela.Documentation.SampleCode.AspectFramework.Testing.SimpleLogTests.MyMethod()");
            try
            {
                Console.WriteLine("Hello, world");
                return;
            }
            finally
            {
                Console.WriteLine($"Leaving Caravela.Documentation.SampleCode.AspectFramework.Testing.SimpleLogTests.MyMethod()");
            }
        }
    }
}
