using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.AspectFramework.Synchronized
{
    class SynchronizedAttribute : Attribute, IAspect<INamedType>
    {
        public void BuildAspect( IAspectBuilder<INamedType> builder )
        {
            foreach ( var method in builder.TargetDeclaration.Methods.Where( m => !m.IsStatic))
            {
                builder.AdviceFactory.OverrideMethod(method, nameof(OverrideMethod));
            }
        }

        [Template]
        private dynamic? OverrideMethod()
        {
            lock ( meta.This )
            {
                return meta.Proceed();
            }
        }
    }
}
