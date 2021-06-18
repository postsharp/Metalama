// @Include(Aspects/SimpleLogAttribute.cs)

using System;
using Caravela.Documentation.SampleCode.CompileTimeTesting.Aspects;

namespace Caravela.Documentation.SampleCode.CompileTimeTesting
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