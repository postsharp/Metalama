using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravela.Documentation.SampleCode.AspectFramework.DeepClone
{
    class NaturallyCloneable : ICloneable
    {
        public object Clone()
        {
            return new NaturallyCloneable();
        }
    }

    [DeepClone]
    class BaseClass
: ICloneable
    {
        int a;
        NaturallyCloneable b;


        public BaseClass Clone()
        {
            var clone = (BaseClass)null;
            clone = (BaseClass)this.MemberwiseClone();
            var clonedField = (NaturallyCloneable)((ICloneable)this.b.Clone());
            clone.b = clonedField;
            return clone;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }

    [DeepClone]
    class DerivedClass : BaseClass
    {
        int c;
        NaturallyCloneable d;


        public override DerivedClass Clone()
        {
            var clone = (DerivedClass)null;
            clone = (DerivedClass)this.MemberwiseClone();
            var clonedField = (NaturallyCloneable)((ICloneable)this.d.Clone());
            clone.d = clonedField;
            return clone;
        }
    }
}