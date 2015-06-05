using ProjectEuler.Interfaces;
using System;
using System.Diagnostics;

namespace ProjectEuler.BaseClasses
{
    public class LoggingLongProblem : ILongProblem
    {
        private ILongProblem _problem;

        public LoggingLongProblem(ILongProblem problem)
        {
            this._problem = problem;
        }

        public long Solve()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = _problem.Solve();

            stopWatch.Stop();

            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed);

            return result;
        }
    }
}