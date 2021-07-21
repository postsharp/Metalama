using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.ConvertToRunTime
{
    internal class TargetCode
    {
        [ConvertToRunTimeAspect]
        private void Method(string a, int c, DateTime e) { }
    }
}
