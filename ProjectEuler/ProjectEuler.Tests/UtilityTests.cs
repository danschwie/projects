using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary.Utilities;

namespace ProjectEuler.Tests
{
    [TestClass]
    public class UtilityTests
    {
        private const int DEFAULT_COMPOSITE = 68;
        private const int DEFAULT_PRIME = 17;

        [TestMethod]
        public void TestIsPrime()
        {
            Assert.IsTrue(Utility.IsPrime(DEFAULT_PRIME));
        }

        [TestMethod]
        public void TestPrimeFactors()
        {
            List<long> primeNumbers = Utility.PrimeFactors(DEFAULT_COMPOSITE);

            Assert.AreEqual(3, primeNumbers.Count);

            Assert.AreEqual(2, primeNumbers[0]);
            Assert.AreEqual(2, primeNumbers[1]);
            Assert.AreEqual(17, primeNumbers[2]);
        }

        [TestMethod]
        public void TestPrimeNumbers()
        {
            List<long> primeNumbers = Utility.PrimeNumbers(DEFAULT_PRIME);

            Assert.AreEqual(7, primeNumbers.Count);

            Assert.AreEqual(2, primeNumbers[0]);
            Assert.AreEqual(3, primeNumbers[1]);
            Assert.AreEqual(5, primeNumbers[2]);
            Assert.AreEqual(7, primeNumbers[3]);
            Assert.AreEqual(11, primeNumbers[4]);
            Assert.AreEqual(13, primeNumbers[5]);
            Assert.AreEqual(17, primeNumbers[6]);
        }

        [TestMethod]
        public void TestSmallestPrimeFactor()
        {
            Assert.AreEqual(2, Utility.SmallestPrimeFactor(DEFAULT_COMPOSITE));
        }

        [TestMethod]
        public void TestLargestPrimeFactor()
        {
            Assert.AreEqual(17, Utility.LargestPrimeFactor(DEFAULT_COMPOSITE));
        }

        [TestMethod]
        public void TestCountPrimeFactors()
        {
            Assert.AreEqual(3, Utility.CountPrimeFactors(DEFAULT_COMPOSITE));
        }

        [TestMethod]
        public void TestSumPrimeFactors()
        {
            Assert.AreEqual(21, Utility.SumPrimeFactors(DEFAULT_COMPOSITE));
        }

        [TestMethod]
        public void TestCountPrimeNumbers()
        {
            Assert.AreEqual(3, Utility.CountPrimeFactors(DEFAULT_COMPOSITE));
        }

        [TestMethod]
        public void TestSumPrimeNumbers()
        {
            Assert.AreEqual(58, Utility.SumPrimeNumbers(DEFAULT_PRIME));
        }

        [TestMethod]
        public void TestFibonacci()
        {
            SequenceGenerator.PrintFibonacci(5);
        }

        [TestMethod]
        public void TestMakeLattice()
        {
            var numSquaresPerSide = 2;
            var g = Utility.MakeSquareLattice(2);

            Assert.AreEqual(g.Vertices.Count, numSquaresPerSide);
        }
    }
}
