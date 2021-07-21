using System;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;
using Caravela.Framework.Eligibility;

namespace Caravela.Documentation.SampleCode.AspectFramework.OverrideMethodAspect_
{
    // <aspect>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class OverrideMethodAspect : Attribute, IAspect<IMethod>
    {
        public virtual void BuildAspect(IAspectBuilder<IMethod> builder)
        {
            builder.AdviceFactory.OverrideMethod(builder.TargetDeclaration, nameof(this.OverrideMethod));
        }

        public virtual void BuildEligibility(IEligibilityBuilder<IMethod> builder)
        {
            builder.ExceptForInheritance().MustBeNonAbstract();
        }

        public virtual void BuildAspectClass(IAspectClassBuilder builder) { }

        [Template]
        public abstract dynamic? OverrideMethod();
    }
    // </aspect>
}
