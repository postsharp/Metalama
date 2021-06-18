using System;

namespace Caravela.Documentation.SampleCode.OverrideMethod.ConvertToRunTime
{
    class TargetCode
    {
        [ConvertToRunTimeAspect]
        void Method(string a, int c, DateTime e) { }
    }
}
