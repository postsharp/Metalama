using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.PrintFieldValues
{
    internal class TargetCode
    {
        private readonly int a;
        public string B { get; set; }

        private static readonly int c;

        [PrintFieldValues]
        public void Method()
        {
            var value = a;
            Console.WriteLine($"a={value}");
            var value_1 = c;
            Console.WriteLine($"c={value_1}");
            var value_2 = B;
            Console.WriteLine($"B={value_2}");
            return;
        }

    }
}
