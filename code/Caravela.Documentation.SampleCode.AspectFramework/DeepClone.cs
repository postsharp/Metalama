using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.DeepClone
{
    class ManuallyCloneable : ICloneable
    {
        public object Clone()
        {
            return new ManuallyCloneable();
        }
    }

    [DeepClone]
    class AutomaticallyCloneable
    {
        int a;

        ManuallyCloneable b;

        AutomaticallyCloneable c;
    }

}
