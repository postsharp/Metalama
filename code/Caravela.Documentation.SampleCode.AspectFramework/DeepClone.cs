using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravela.Documentation.SampleCode.AspectFramework.DeepClone
{
    class ManuuallyCloneable : ICloneable
    {
        public object Clone()
        {
            return new ManuuallyCloneable();
        }
    }

    [DeepClone]
    class AutomaticallyCloneable
    {
        int a;

        ManuuallyCloneable b;

        AutomaticallyCloneable c;
    }

}
