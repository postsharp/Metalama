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
    class AutomaticallyCloneable : ICloneable
    {
        int a;

        ManuallyCloneable b;

        AutomaticallyCloneable c;


        public AutomaticallyCloneable Clone()
        {
            var clone = (AutomaticallyCloneable?)null;
            clone = (AutomaticallyCloneable)base.MemberwiseClone();
            clone.b = (ManuallyCloneable)b.Clone();
            clone.c = c.Clone();
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }

}
