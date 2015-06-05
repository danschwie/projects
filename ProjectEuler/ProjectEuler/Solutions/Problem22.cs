using MathLibrary.Utilities;
using ProjectEuler.Interfaces;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ProjectEuler.Solutions
{
    public class Problem22 : ILongProblem
    {
        private Dictionary<char, int> _dictionary;

        public long Solve()
        {
            InitializeDictionary();
            var runningTotal = 0;
            var line = "";
            var names = new List<string>();

            using (StreamReader reader = new StreamReader(@"C:\Users\dschwie\Desktop\working\projects\ProjectEuler\ProjectEuler\Resources\Problem22\p022_names.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\"", "");
                    names.AddRange(line.Split(',').ToList());
                }
            }

            names.Sort();

            for (int i = 0; i < names.Count; i++)
            {
                var position = i + 1;

                runningTotal += position * GetAlphabeticalValue(names[i]);
            }

            return runningTotal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int GetAlphabeticalValue(string s)
        {
            var alphabeticalValue = 0;

            foreach (char c in s)
            {
                alphabeticalValue += _dictionary[c];
            }

            return alphabeticalValue;
        }

        private void InitializeDictionary()
        {
            _dictionary = new Dictionary<char, int>();

            _dictionary.Add('A', 1);
            _dictionary.Add('B', 2);
            _dictionary.Add('C', 3);
            _dictionary.Add('D', 4);
            _dictionary.Add('E', 5);
            _dictionary.Add('F', 6);
            _dictionary.Add('G', 7);
            _dictionary.Add('H', 8);
            _dictionary.Add('I', 9);
            _dictionary.Add('J', 10);
            _dictionary.Add('K', 11);
            _dictionary.Add('L', 12);
            _dictionary.Add('M', 13);
            _dictionary.Add('N', 14);
            _dictionary.Add('O', 15);
            _dictionary.Add('P', 16);
            _dictionary.Add('Q', 17);
            _dictionary.Add('R', 18);
            _dictionary.Add('S', 19);
            _dictionary.Add('T', 20);
            _dictionary.Add('U', 21);
            _dictionary.Add('V', 22);
            _dictionary.Add('W', 23);
            _dictionary.Add('X', 24);
            _dictionary.Add('Y', 25);
            _dictionary.Add('Z', 26);
        }
    }
}
