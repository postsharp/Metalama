using System;

namespace Caravela.Documentation.SampleCode.OverrideMethod.SimpleLogging
{
    class TargetCode
    {
        [SimpleLog]
        public void Method1()
{
    global::System.Console.WriteLine($"Entering Caravela.Documentation.SampleCode.OverrideMethod.SimpleLogging.TargetCode.Method1()");
    try
    {
            Console.WriteLine("Hello, world.");
        return;
    }
    finally
    {
        global::System.Console.WriteLine($"Leaving Caravela.Documentation.SampleCode.OverrideMethod.SimpleLogging.TargetCode.Method1()");
    }
}
    }
}
