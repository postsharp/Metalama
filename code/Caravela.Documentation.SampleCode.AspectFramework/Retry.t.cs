using System;
using System.Threading;

namespace Caravela.Documentation.SampleCode.AspectFramework.Retry
{
    internal class TargetCode
    {
        [Retry]
        private void RetryDefault()
        {
            for (var i = 0; ; i++)
            {
                try
                {
                    throw new Exception();
                    return;
                }
                catch (Exception e) when (i < 5)
                {
                    Console.WriteLine($"{e.Message}. Retrying in 100 ms.");
                    Thread.Sleep(100);
                }
            }
        }

        [Retry(MaxAttempts = 10)]
        private void RetryTenTimes()
        {
            for (var i = 0; ; i++)
            {
                try
                {
                    throw new Exception();
                    return;
                }
                catch (Exception e) when (i < 10)
                {
                    Console.WriteLine($"{e.Message}. Retrying in 100 ms.");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
