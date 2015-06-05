using MathLibrary;
using MathLibrary.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectEuler.Tests
{
    [TestClass]
    public class BigIntTests
    {
        private BigInt MIN_BIG_INT = 123456789;
        private BigInt SAME_AS_MIN_BIG_INT = 123456789;
        private BigInt SLIGHTLY_GREATER_THAN_MIN = 123456799;
        private BigInt LESS_DIGITS_THAN_MIN = 98765432;
        private BigInt MAX_BIG_INT = 987654321;

        [TestMethod]
        public void StringConstructorTest()
        {
            try
            {
                BigInt b = "Here are some non-numeric charaters";
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Value must be a valid integer\r\nParameter name: s", ae.Message);
            }
        }

        [TestMethod]
        public void AddTest()
        {
            BigInt b1 = "22222222222222222222222222222222222";
            BigInt b2 = "33333333333333333333333333333333333";
            BigInt sum = b1 + b2;
            BigInt expected = "55555555555555555555555555555555555";

            Assert.AreEqual(expected, sum);
        }

        [TestMethod]
        public void LessThanTest()
        {
            Assert.IsTrue(MIN_BIG_INT < MAX_BIG_INT);
            Assert.IsFalse(MAX_BIG_INT < MIN_BIG_INT);
            Assert.IsFalse(MIN_BIG_INT < SAME_AS_MIN_BIG_INT);
        }

        [TestMethod]
        public void GreaterThanTest()
        {
            Assert.IsTrue(MAX_BIG_INT > MIN_BIG_INT);
            Assert.IsFalse(MIN_BIG_INT > MAX_BIG_INT);
            Assert.IsFalse(MIN_BIG_INT > SAME_AS_MIN_BIG_INT);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Assert.AreEqual(MIN_BIG_INT, SAME_AS_MIN_BIG_INT);
            Assert.AreNotEqual(MIN_BIG_INT, MAX_BIG_INT);
        }

        [TestMethod]
        public void CompareTest()
        {
            Assert.AreEqual(-1, BigInt.Compare(MIN_BIG_INT, MAX_BIG_INT));
            Assert.AreEqual(1, BigInt.Compare(MAX_BIG_INT, MIN_BIG_INT));
            Assert.AreEqual(0, BigInt.Compare(MIN_BIG_INT, SAME_AS_MIN_BIG_INT));
            Assert.AreEqual(-1, BigInt.Compare(MIN_BIG_INT, SLIGHTLY_GREATER_THAN_MIN));
            Assert.AreEqual(1, BigInt.Compare(MIN_BIG_INT, LESS_DIGITS_THAN_MIN));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("123456789", MIN_BIG_INT.ToString());
            Assert.AreNotEqual("987654321", MIN_BIG_INT.ToString());
        }

        [TestMethod]
        public void LongestTest()
        {
            Assert.AreEqual(MIN_BIG_INT, BigInt.Longest(MIN_BIG_INT, LESS_DIGITS_THAN_MIN));
            Assert.AreEqual(MIN_BIG_INT, BigInt.Longest(LESS_DIGITS_THAN_MIN, MIN_BIG_INT));
            Assert.IsNull(BigInt.Longest(MIN_BIG_INT, SAME_AS_MIN_BIG_INT));
        }

        [TestMethod]
        public void MaxTest()
        {
            Assert.AreEqual(MAX_BIG_INT, BigInt.Max(MIN_BIG_INT, MAX_BIG_INT));
            Assert.AreEqual(MAX_BIG_INT, BigInt.Max(MAX_BIG_INT, MIN_BIG_INT));
            Assert.IsNull(BigInt.Max(MIN_BIG_INT, SAME_AS_MIN_BIG_INT));
            Assert.AreEqual(SLIGHTLY_GREATER_THAN_MIN, BigInt.Max(MIN_BIG_INT, SLIGHTLY_GREATER_THAN_MIN));
            Assert.AreEqual(MIN_BIG_INT, BigInt.Max(MIN_BIG_INT, LESS_DIGITS_THAN_MIN));
        }

        [TestMethod]
        public void MinTest()
        {
            Assert.AreEqual(MIN_BIG_INT, BigInt.Min(MIN_BIG_INT, MAX_BIG_INT));
            Assert.AreEqual(MIN_BIG_INT, BigInt.Min(MAX_BIG_INT, MIN_BIG_INT));
            Assert.IsNull(BigInt.Min(MIN_BIG_INT, SAME_AS_MIN_BIG_INT));
            Assert.AreEqual(MIN_BIG_INT, BigInt.Min(MIN_BIG_INT, SLIGHTLY_GREATER_THAN_MIN));
            Assert.AreEqual(LESS_DIGITS_THAN_MIN, BigInt.Min(MIN_BIG_INT, LESS_DIGITS_THAN_MIN));
        }

        [TestMethod]
        public void GetDigitListTests()
        {
            var n = 951357;
            var digitList = BigIntUtility.ToByteList(n);

            Assert.AreEqual(9, digitList[0]);
            Assert.AreEqual(5, digitList[1]);
            Assert.AreEqual(1, digitList[2]);
            Assert.AreEqual(3, digitList[3]);
            Assert.AreEqual(5, digitList[4]);
            Assert.AreEqual(7, digitList[5]);
        }
    }
}
