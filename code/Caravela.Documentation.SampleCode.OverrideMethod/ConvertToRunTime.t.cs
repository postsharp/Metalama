using System;

namespace Caravela.Documentation.SampleCode.OverrideMethod.ConvertToRunTime
{
    class TargetCode
    {
        [ConvertToRunTimeAspect]
        void Method(string a, int c, DateTime e) {
    var parameterNames = new global::System.Collections.Generic.List<global::System.String>{"a", "c", "e"};
    var buildTime = new global::System.Guid(331430378, 17141, 18214, 137, 77, 85, 4, 6, 53, 121, 120);
    var parameterType = global::System.Type.GetTypeFromHandle(global::Caravela.Compiler.Intrinsics.GetRuntimeTypeHandle("T:System.String"));
    return;
}
    }
}
