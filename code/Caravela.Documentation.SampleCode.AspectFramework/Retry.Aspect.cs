using System;
using System.Threading;
using Caravela.Framework.Aspects;

namespace Caravela.Documentation.SampleCode.AspectFramework.Retry
{
    internal class RetryAttribute : OverrideMethodAspect
    {
        public int MaxAttempts { get; set; } = 5;

        public override dynamic OverrideMethod()
        {
            for (var i = 0; ; i++)
            {
                try
                {
                    return meta.Proceed();
                }
                catch (Exception e) when (i < this.MaxAttempts)
                {
                    Console.WriteLine($"{e.Message}. Retrying in 100 ms.");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
