using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.OverrideMethod
{
    public class EmptyOverrideMethodAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod() => throw new System.NotSupportedException("Compile-time only code cannot be called at run-time.");
    }
}