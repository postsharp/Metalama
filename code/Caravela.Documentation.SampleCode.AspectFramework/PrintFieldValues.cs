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

        }

    }
}
