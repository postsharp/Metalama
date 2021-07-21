using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework
{
    public class EmptyOverrideMethodAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            return meta.Proceed();
        }
    }
}
