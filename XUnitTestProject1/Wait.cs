using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace XUnitTestProject1
{
    public static class Wait
    {
        private const int RetryInterval = 100;

        public static bool For(Func<bool> predicate, int timeoutSec = 30)
        {
            var timer = Stopwatch.StartNew();
            var timeout = TimeSpan.FromSeconds(timeoutSec);
            while (timer.Elapsed <= timeout)
            {
                if (predicate())
                {
                    return true;
                }
                Thread.Sleep(RetryInterval);
            }
            return false;
        }
    }
}
