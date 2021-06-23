using System;

namespace Caravela.Documentation.SampleCode.AspectFramework.Retry
{
    internal class TargetCode
    {
        [Retry]
        private void RetryDefault()
        {
            throw new Exception();
        }

        [Retry(MaxAttempts = 10)]
        private void RetryTenTimes()
        {
            throw new Exception();
        }
    }
}
