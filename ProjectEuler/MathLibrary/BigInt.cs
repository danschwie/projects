using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MathLibrary.Utilities;

namespace MathLibrary
{
    public class BigInt
    {
        #region - Private Variables -

        private List<byte> _bytes;

        #endregion

        #region - Properties -

        private List<byte> Bytes
        {
            get
            {
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        }

        private bool Signed
        {
            get;
            set;
        }

        public int Length 
        {
            get
            {
                return Bytes.Count();
            }
        }

        #endregion

        #region - Constructors -

        public BigInt()
            : this(0)
        {
        }

        public BigInt(int n)
            : this(n.ToString())
        {
        }

        public BigInt(long n)
            : this(n.ToString())
        {
        }

        public BigInt(string s)
        {
            if (!Regex.IsMatch(s, "^[-+]?([0-9])+$"))
            {
                throw (new ArgumentException("Value must be a valid integer", "s"));
            }

            if (s.StartsWith("-"))
            {
                this.Signed = true;
                s = s.Replace("-", "");
            }

            Bytes = BigIntUtility.ToByteList(s);
        }

        #endregion

        #region - Operators -

        public static implicit operator BigInt(int n)
        {
            return new BigInt(n);
        }

        public static implicit operator BigInt(long n)
        {
            return new BigInt(n);
        }

        public static implicit operator BigInt(string s)
        {
            return new BigInt(s);
        }

        public static BigInt operator +(BigInt addend1, BigInt addend2)
        {
            var result = new BigInt() { Bytes = new List<byte>() };

            if (addend1.Signed || addend2.Signed)
            {
                // Only addend1 is negative.
                if (!addend2.Signed)
                {
                    result = addend2 - addend1;
                    return result;
                }
                else
                {
                    // Only addend2 is negative.
                    if (!addend1.Signed)
                    {
                        result = addend1 - addend2;
                        return result;
                    }
                    else
                    {
                        // Both addends are negative.
                        if (addend1.Signed && addend2.Signed)
                        {
                            // Temporarily remove the signs or we will enter an infinitely recursive loop.
                            addend1.Signed = false;
                            addend2.Signed = false;

                            // Add the results and mark the sum as negative.
                            result = addend1 + addend2;
                            result.Signed = true;

                            return result;
                        }
                    }
                }
            }

            // Both addends are positive.
            var longest = Longest(addend1, addend2);

            var limit = 0;

            if (longest != null)
            {
                limit = longest.Bytes.Count;
                Min(addend1, addend2).Pad(limit);
            }
            else
            {
                limit = addend1.Bytes.Count;
            }

            byte carry = 0;

            for (int i = limit - 1; i >= 0; i--)
            {
                var temp = 0;

                temp = addend1.Bytes[i] + addend2.Bytes[i] + carry;
                carry = (byte)(temp >= 10 ? 1 : 0);
                result.Bytes.Add(temp >= 10 ? (byte)(temp - 10) : (byte)(temp));
            }

            if (carry == 1)
            {
                result.Bytes.Add(1);
            }

            result.Reverse();
            return result;
        }

        public static BigInt operator -(BigInt minuend, BigInt subtrahend)
        {
            var result = new BigInt() { Bytes = new List<byte>() };

            // Result is guaranteed to be negative if the minuend is less than the subtrahend.
            result.Signed = minuend < subtrahend;

            var max = Max(minuend, subtrahend);
            var min = Min(minuend, subtrahend);

            if (max == null)
            {
                return new BigInt(0);
            }

            var limit = max.Bytes.Count;
            min.Pad(limit);

            for (int i = limit - 1; i >= 0; i--)
            {
                var temp = 0;

                if (max.Bytes[i] >= min.Bytes[i])
                {
                    temp = max.Bytes[i] - min.Bytes[i];
                }
                else
                {
                    var j = i - 1;

                    while (j >= 0 && max.Bytes[j] == 0)
                    {
                        j--;
                    }
                    max.Bytes[j] -= 1;

                    while (++j < i)
                    {
                        max.Bytes[j] = 9;
                    }

                    temp = (max.Bytes[i] + 10) - min.Bytes[i];
                }

                result.Bytes.Add((byte)temp);
            }

            result.Reverse();
            result.Trim();

            return result;
        }

        public static BigInt operator *(BigInt factor1, BigInt factor2)
        {
            BigInt multiplicand = factor1 > factor2 ? factor1 : factor2;
            BigInt multiplier = factor1 > factor2 ? factor2 : factor1;
            BigInt product = 0;

            for (int i = 0; i < multiplier; i++)
            {
                product += multiplicand;
            }

            return product;
        }

        public static BigInt operator <<(BigInt b, int n)
        {
            for (int i = 0; i < n; i++)
            {
                b.Bytes.Add(0);
            }

            return b;
        }

        public static BigInt operator >>(BigInt b, int n)
        {
            for (int i = b.Bytes.Count - (n + 1); i >= 0; i--)
            {
                b.Bytes[i + n] = b.Bytes[i];
            }

            b.Bytes.RemoveRange(0, n);

            return b;
        }

        public static bool operator <(BigInt b1, BigInt b2)
        {
            return Compare(b1, b2) == -1;
        }

        public static bool operator >(BigInt b1, BigInt b2)
        {
            return Compare(b1, b2) == 1;
        }

        public BigInt Abs()
        {
            var abs = this;
            abs.Signed = false;
            return abs;
        }

        public static short Compare(BigInt b1, BigInt b2)
        {
            if (b1.Bytes.Count > b2.Bytes.Count)
            {
                return 1;
            }
            else
            {
                if (b2.Bytes.Count > b1.Bytes.Count)
                {
                    return -1;
                }
                // Byte counts are equal.
                else
                {
                    for (int i = 0; i < b1.Bytes.Count; i++)
                    {
                        if (b1.Bytes[i] > b2.Bytes[i])
                        {
                            return 1;
                        }
                        else
                        {
                            if (b2.Bytes[i] > b1.Bytes[i])
                            {
                                return -1;
                            }
                        }
                    }
                    return 0;
                }
            }
        }

        #endregion

        #region - Static Methods -

        public static BigInt Longest(BigInt b1, BigInt b2)
        {
            if (b1.Bytes.Count > b2.Bytes.Count)
            {
                return b1;
            }
            else
            {
                if (b2.Bytes.Count > b1.Bytes.Count)
                {
                    return b2;
                }
            }

            return null;
        }

        public static BigInt Max(BigInt b1, BigInt b2)
        {
            var result = Compare(b1, b2);

            if (result == 1)
            {
                return b1;
            }
            else
            {
                if (result == -1)
                {
                    return b2;
                }
                else
                {
                    return null;
                }
            }
        }

        public static BigInt Min(BigInt b1, BigInt b2)
        {
            var result = Compare(b1, b2);

            if (result == -1)
            {
                return b1;
            }
            else
            {
                if (result == 1)
                {
                    return b2;
                }
                else
                {
                    return null;
                }
            }
        }

        public static BigInt Pow(BigInt b, int power)
        {
            BigInt result = 1;

            if (power == 0)
            {
                return 1;
            }
            else
            {
                if (power > 0)
                {
                    for (int i = 1; i <= power; i++)
                    {
                        result = result * b;
                    }
                }
                else
                {
                    // Negative powers not currently supported.
                    return -1;
                }
            }

            return result;
        }

        #endregion

        #region - Base Class Overrides -

        public override bool Equals(object obj)
        {
            return Compare(this, (BigInt)obj) == 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Bytes.Count);

            if (this.Signed)
            {
                sb.Append("-");
            }

            for (int i = 0; i < Bytes.Count; i++)
            {
                sb.Append(Bytes[i].ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region - Instance Methods -

        public BigInt Clone()
        {
            return null;
        }

        public void Pad(int ceiling)
        {
            var paddedBytes = new List<byte>(ceiling);
            var offset = ceiling - this.Bytes.Count;

            for (int i = 0; i < offset; i++)
            {
                paddedBytes.Add(0);
            }

            for (int i = offset; i < ceiling; i++)
            {
                paddedBytes.Add(this.Bytes[i - offset]);
            }

            this.Bytes.Clear();
            this.Bytes = paddedBytes;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Bytes.Count / 2; i++)
            {
                var temp = this.Bytes[i];
                this.Bytes[i] = this.Bytes[this.Bytes.Count - (i + 1)];
                this.Bytes[this.Bytes.Count - (i + 1)] = temp;
            }
        }

        public BigInt SumDigits()
        {
            BigInt sum = new BigInt(0);

            for (int i = 0; i < Bytes.Count; i++)
            {
                sum += Bytes[i];
            }

            return sum;
        }

        public void Trim()
        {
            var i = 0;

            while (this.Bytes[i] == 0)
            {
                this.Bytes.RemoveAt(i);
            }
        }

        #endregion
    }
}