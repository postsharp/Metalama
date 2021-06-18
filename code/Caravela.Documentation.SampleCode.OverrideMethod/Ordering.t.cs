using System;
using Caravela.Documentation.SampleCode.OverrideMethod.Ordering;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.OverrideMethod.Ordering
{
    [Aspect1, Aspect2]
    class TargetCode
    {
        public void SourceMethod() 
{
    global::System.Console.WriteLine("Executing Aspect1. Methods present before applying Aspect1: SourceMethod, Method2");
    global::System.Console.WriteLine("Executing Aspect2. Methods present before applying Aspect2: SourceMethod");
            Console.WriteLine("Method defined in source code.");
goto__aspect_return_1;__aspect_return_1:;    return;
}


public void Method2()
{
    global::System.Console.WriteLine("Executing Aspect1. Methods present before applying Aspect1: SourceMethod, Method2");
    global::System.Console.WriteLine("Method introduced by Aspect2.");
    return;
}

public void Method1()
{
    global::System.Console.WriteLine("Method introduced by Aspect1.");
}    }
}