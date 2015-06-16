using System;
using System.Collections.Generic;
using ProjectEuler.Solutions;
using MathLibrary.Utilities;
using MathLibrary;
using ProjectEuler.BaseClasses;
using ProjectEuler.Interfaces;
using System.Diagnostics;

namespace ProjectEulerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveIntResultProblem(new Problem67());
        }

        static void SolveIntResultProblem(IIntProblem problemToExecute)
        {
            Console.WriteLine(new LoggingIntProblem(problemToExecute).Solve());
        }

        static void SolveLongResultProblem(ILongProblem problemToExecute)
        {
            Console.WriteLine(new LoggingLongProblem(problemToExecute).Solve());
        }
    }
}
