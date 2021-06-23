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
            var value = (this).a;
            System.Console.WriteLine($"a={value}");
            var value_1 = TargetCode.c;
            System.Console.WriteLine($"c={value_1}");
            var value_2 = (this).B;
            System.Console.WriteLine($"B={value_2}");
            return;
        }

    }
}