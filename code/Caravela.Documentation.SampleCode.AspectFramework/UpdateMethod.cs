using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.UpdateMethod
{
    [UpdateMethod]
    class TargetCode
    {
        int x;

        public string Y { get; private set; }

        public DateTime Z { get; }
    }
}
