using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.OverrideMethod
{
    public class EmptyOverrideMethodAttribute : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            return meta.Proceed();
        }
    }
}
