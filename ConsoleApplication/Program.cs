using Google.Apis.Auth.OAuth2;
using Google.Apis.Dfareporting.v2_0;
using Google.Apis.Dfareporting.v2_0.Data;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using ConsoleApplication.Classes;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 33, 52, 4, 21 };

            var n = numbers.Where(i => i > 16).Select(i).ToList();
        }

        static bool IsPalindrome(string s)
        {
            var normalized = s.Replace(" ", "").ToLower();

            if (normalized.Length <= 1)
            {
                return true;
            }
            else
            {
                var firstChar = normalized[0];
                var lastChar = normalized[normalized.Length - 1];

                return firstChar == lastChar
                    ? IsPalindrome(normalized.Substring(1, normalized.Length - 2))
                    : false;
            }
        }
    }
}
