using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.Tags
{
    class TargetCode
    {
        [TagsAspect]
        void Method(int a, int b)
        {
            Console.WriteLine($"This method has 2 parameters.");
            Console.WriteLine("This is the method.");
            return;
        }
    }
}
