using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MapReduce
{
    public class Utility
    {
        // Path to directory containing text files for processing.
        public const string DATA_DIRECTORY = @"C:\Users\dschwie\Desktop\working\projects\FunctionalProgrammingDemo\MapReduce\data\";

        const string INPUT_FILE_1_NAME = "George_W_Bush_State_of_the_Union_January_29_2002.txt";
        const string INPUT_FILE_2_NAME = "Barack_Obama_State_of_the_Union_January_24_2012.txt";

        public static IEnumerable<KeyValuePair<string, string>> GetInputData()
        {
            try
            {
                return new List<KeyValuePair<string, string>>() 
                { 
                    new KeyValuePair<string, string>(INPUT_FILE_1_NAME, CleanString(File.ReadAllText(string.Concat(DATA_DIRECTORY, INPUT_FILE_1_NAME))))
                    , new KeyValuePair<string, string>(INPUT_FILE_2_NAME, CleanString(File.ReadAllText(string.Concat(DATA_DIRECTORY, INPUT_FILE_2_NAME))))
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static string CleanString(string s)
        {
            s = s.Replace(".", "");
            s = s.Replace(",", "");
            s = s.Replace("?", "");
            s = s.Replace("'", "");
            s = s.Replace(":", "");
            s = s.Replace(";", "");
            s = s.Replace("\"", "");
            s = s.Replace("(", "");
            s = s.Replace(")", "");
            s = s.Replace(" --", "");

            return s.ToLower();
        }

        public static bool IsPalindrome(string s)
        {
            return s == Reverse(s);
        }

        public static string Reverse(string s)
        {
            if (s.Length == 0)
            {
                return s;
            }
            else
            {
                return Reverse(s.Substring(1, s.Length - 1)) + s.Substring(0, 1);
            }
        }
    }
}