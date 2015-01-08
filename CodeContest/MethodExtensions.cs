using System;
using System.Diagnostics;

namespace CodeContest
{
    public static class MethodExtensions
    {
        public static Tuple<string, DateTime, TimeSpan> TimeThisMethod(Action action, string name)
        {
            var startTime = DateTime.Now;
            var sw = Stopwatch.StartNew();

            action();

            sw.Stop();
            return new Tuple<string, DateTime, TimeSpan>(name, startTime,
                sw.Elapsed);
        }
    }
}