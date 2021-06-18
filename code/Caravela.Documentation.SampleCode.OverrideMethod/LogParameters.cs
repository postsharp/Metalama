// <aspect>
using System;
using System.Text;
using Caravela.Framework.Aspects;
using Caravela.Framework.Code;

namespace Caravela.Documentation.SampleCode.OverrideMethod.LogParameters
{
    class TargetCode
    {
        [Log]
        void VoidMethod(int a, out int b)
        {
            b = a;
        }

        [Log]
        int IntMethod(int a)
        {
            return a;
        }

    }
}