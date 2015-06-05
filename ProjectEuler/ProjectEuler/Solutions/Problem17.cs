using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using ProjectEuler.Shared;
using Logging;

namespace ProjectEuler.Solutions
{
    // If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 
    // 3 + 3 + 5 + 4 + 4 = 19 letters used in total. If all the numbers from 1 to 1000 (one thousand) inclusive 
    // were written out in words, how many letters would be used?
    // NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters 
    // and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in 
    // compliance with British usage.
    public class Problem17 : IIntProblem
    {
        private int _totalChars = 0;

        public int Solve()
        {
            StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["LogFilePath"]);

            for (int i = 1; i <= 1000; i++)
            {
                string s = GetStringRepresentation(i);

                //writer.WriteLine(s);

                _totalChars += s.Length;
            }

            writer.Close();
            return _totalChars;
        }

        private string GetStringRepresentation(int n)
        {
            var intString = n.ToString();
            var chars = intString.ToCharArray();

            switch (chars.Length)
            {
                case 1:
                    return OneDigitNumberToString(chars);
                case 2:
                    return TwoDigitNumberToString(chars);
                case 3:
                    return ThreeDigitNumberToString(chars);
                case 4:
                    return FourDigitNumberToString(chars);
                default:
                    return "";
            }
        }

        private string OneDigitNumberToString(char[] chars)
        {
            return GetStringTranslation(chars[0]);
        }

        private string TwoDigitNumberToString(char[] chars)
        {
            if (chars[0] == '1')
            {
                return GetTeenRepresentation(chars[1]);
            }

            return string.Concat(
              GetStringTranslation(chars[0], true),
              GetStringTranslation(chars[1]));
        }

        private string ThreeDigitNumberToString(char[] chars)
        {
            string s = "";

            if (chars[1] == '1')
            {
                s = string.Concat(
                  GetStringTranslation(chars[0]),
                  "hundredand",
                  GetTeenRepresentation(chars[2]));
            }
            else
            {
                s = string.Concat(
                GetStringTranslation(chars[0]),
                "hundredand",
                GetStringTranslation(chars[1], true),
                GetStringTranslation(chars[2]));
            }

            if (chars[1] == '0' && chars[2] == '0')
            {
                s = s.Remove(s.Length - 3, 3);
            }

            return s;
        }

        private string FourDigitNumberToString(char[] chars)
        {
            string s = "";

            if (chars[2] == '1')
            {
                s = string.Concat(
                  GetStringTranslation(chars[0]),
                  "thousand",
                  GetStringTranslation(chars[1]),
                  "hundredand",
                  GetTeenRepresentation(chars[3]));
            }
            else
            {
                s = string.Concat(
                  GetStringTranslation(chars[0]),
                  "thousand",
                  GetStringTranslation(chars[1]),
                  "hundredand",
                  GetStringTranslation(chars[2], true),
                  GetStringTranslation(chars[3]));
            }

            if (chars[2] == '0' && chars[3] == '0')
            {
                s = s.Remove(s.Length - 3, 3); ;

                if (chars[1] == '0')
                {
                    s = s.Replace("hundred", "");
                }
            }

            return s;
        }

        private string GetStringTranslation(char c)
        {
            return GetStringTranslation(c, false);
        }

        private string GetStringTranslation(char c, bool isTensPlace)
        {
            switch (c)
            {
                case '1':
                    return isTensPlace ? "" : "one";
                case '2':
                    return isTensPlace ? "twenty" : "two";
                case '3':
                    return isTensPlace ? "thirty" : "three";
                case '4':
                    return isTensPlace ? "forty" : "four";
                case '5':
                    return isTensPlace ? "fifty" : "five";
                case '6':
                    return isTensPlace ? "sixty" : "six";
                case '7':
                    return isTensPlace ? "seventy" : "seven";;
                case '8':
                    return isTensPlace ? "eighty" : "eight";
                case '9':
                    return isTensPlace ? "ninety" : "nine";
                case '0':
                    return "";
                default:
                    return "";
            }
        }

        private string GetTeenRepresentation(char c)
        {
            switch (c)
            {
                case '1':
                    return "eleven";
                case '2':
                    return "twelve";
                case '3':
                    return "thirteen";
                case '4':
                    return "fourteen";
                case '5':
                    return "fifteen";
                case '6':
                    return "sixteen";
                case '7':
                    return "seventeen";
                case '8':
                    return "eighteen";
                case '9':
                    return "nineteen";
                case '0':
                    return "ten";
                default:
                    return "";         
            }
        }
    }
}