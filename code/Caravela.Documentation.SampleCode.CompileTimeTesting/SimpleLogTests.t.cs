using System;
using Caravela.Documentation.SampleCode.CompileTimeTesting.Aspects;

namespace Caravela.Documentation.SampleCode.CompileTimeTesting
{
    class SimpleLogTests
    {
        [SimpleLog]
        void MyMethod()
        {
            global::System.Console.WriteLine($"Entering  Caravela.Documentation.SampleCode.CompileTimeTesting.SimpleLogTests.MyMethod()");
            try
            {
                Console.WriteLine("Hello, world");
                return;
            }
            finally
            {
                global::System.Console.WriteLine($"Leaving  Caravela.Documentation.SampleCode.CompileTimeTesting.SimpleLogTests.MyMethod()");
            }
        }
    }
}