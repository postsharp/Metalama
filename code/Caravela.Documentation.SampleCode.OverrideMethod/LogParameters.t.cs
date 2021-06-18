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
    var arguments = new object[]{a, 0};
    global::System.Console.WriteLine("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> ) started", arguments);
    try
    {
        global::Caravela.Framework.Aspects.__Void result;
            b = a;
        global::System.Console.WriteLine(string.Format("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> )", arguments) + " returned " + result);
        return;
    }
    catch (global::System.Exception e)
    {
        global::System.Console.WriteLine("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.VoidMethod(a = {0}, b = <out> ) failed: " + e, arguments);
        throw;
    }
}

        [Log]
        int IntMethod(int a)
{
    var arguments = new object[]{a};
    global::System.Console.WriteLine("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.IntMethod(a = {0}) started", arguments);
    try
    {
        global::System.Int32 result;
result=a;        global::System.Console.WriteLine(string.Format("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.IntMethod(a = {0})", arguments) + " succeeded");
        return (int)result;
    }
    catch (global::System.Exception e)
    {
        global::System.Console.WriteLine("Caravela.Documentation.SampleCode.OverrideMethod.LogParameters.TargetCode.IntMethod(a = {0}) failed: " + e, arguments);
        throw;
    }
}

    }
}