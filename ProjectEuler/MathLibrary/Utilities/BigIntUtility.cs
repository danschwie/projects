using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary.Utilities
{
    public class BigIntUtility
    {
        public static List<byte> ToByteList(int n)
        {
            return ToByteList(n.ToString());
        }

        public static List<byte> ToByteList(string s)
        {
            var result = new List<byte>(s.Length);
            var chars = s.ToCharArray();

            foreach (char c in chars)
            {
                result.Add(Convert.ToByte(c.ToString()));
            }

            return result;
        }
    }
}
