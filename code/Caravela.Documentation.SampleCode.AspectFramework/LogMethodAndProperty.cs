namespace Caravela.Documentation.SampleCode.AspectFramework.LogMethodAndProperty
{
    internal class TargetCode
    {
        [Log]
        public int Method(int a, int b)
        {
            return a + b;
        }

        [Log]
        public int Property { get; set; }

        [Log]
        public string Field { get; set; }
    }
}
