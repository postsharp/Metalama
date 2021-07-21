using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework
{
    public class EmptyOverrideFieldOrPropertyAttribute : OverrideFieldOrPropertyAspect
    {
        public override dynamic OverrideProperty
        {
            get => throw new System.NotSupportedException("Compile-time only code cannot be called at run-time.");
            set => throw new System.NotSupportedException("Compile-time only code cannot be called at run-time.");
        }

    }
}
