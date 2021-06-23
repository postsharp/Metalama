using System;
using System.Linq;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.ConvertToRunTime
{
    internal class ConvertToRunTimeAspect : OverrideMethodAspect
    {
        public override dynamic OverrideMethod()
        {
            var parameterNamesCompileTime = meta.Parameters.Select(p => p.Name).ToList();
            var parameterNames = meta.RunTime(parameterNamesCompileTime);
            var buildTime = meta.RunTime(new Guid("13c139ea-42f5-4726-894d-550406357978"));

            // In the next line, a call to meta.RunTime is redundant because the return value of ToType 
            // is marked as run-time.
            var parameterType = meta.Parameters[0].ParameterType.ToType();

            return null;
        }
    }
}
