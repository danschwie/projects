using ProjectEuler.Interfaces;
using System;
using System.Diagnostics;

namespace ProjectEuler.BaseClasses
{
    public class LoggingIntProblem : IIntProblem
    {
        private IIntProblem _problem;

        public LoggingIntProblem(IIntProblem problem)
        {
            this._problem = problem;
        }

        public int Solve()
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