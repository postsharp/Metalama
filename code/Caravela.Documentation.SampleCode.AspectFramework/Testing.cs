using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.Testing
{
    class SimpleLogTests
    {
        [SimpleLog]
        void MyMethod()
        {
            Console.WriteLine("Hello, world");
        }
    }
}
