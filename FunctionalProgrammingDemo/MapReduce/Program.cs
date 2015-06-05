using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MapReduce
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoWordCountMapReduceDemo();
            DoWordContextMapReduceDemo();
        }

        #region - Word Count Map-Reduce Demo -

        static void DoWordCountMapReduceDemo()
        {
            // implements public class Master<K1, V1, K2, V2, V3>
            Master<string, string, string, int, int> master = new Master<string, string, string, int, int>(WordCountMapFunction, WordCountReduceFunction);

            foreach (KeyValuePair<string, IEnumerable<KeyValuePair<string, int>>> result in master.Execute(Utility.GetInputData()))
            {
                var orderedResult = result.Value.OrderByDescending(v => v.Value);

                using (StreamWriter file = new StreamWriter(string.Concat(Utility.DATA_DIRECTORY, string.Format("{0}.csv", result.Key))))
                {
                    int totalWords = orderedResult.Sum(k => k.Value);

                    foreach (KeyValuePair<string, int> kvp in orderedResult)
                    {
                        decimal frequency = ((decimal)kvp.Value / totalWords) * 100;

                        file.WriteLine(string.Format("{0},{1},{2}", kvp.Key, kvp.Value, Math.Round(frequency, 3)));
                    }

                    file.WriteLine(string.Format("Total Words: {0},", totalWords));
                }
            }
        }

        // Master<K1, V1, K2, V2, V3>
        // implements public delegate IEnumerable<KeyValuePair<K2, V2>> MapFunction(K1 key, V1 value);
        static IList<KeyValuePair<string, int>> WordCountMapFunction(string key, string value)
        {
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();

            foreach (var word in value.Split(new string[] { " ", "\r\n" }, System.StringSplitOptions.None))
            {
                result.Add(new KeyValuePair<string, int>(word, 1));
            }

            return result;
        }

        // Master<K1, V1, K2, V2, V3>
        // implements public delegate IEnumerable<V3> ReduceFunction(K2 key, IEnumerable<V2> values); 
        // concrete implementation: 
        static IEnumerable<int> WordCountReduceFunction(string key, IEnumerable<int> values)
        {
            int sum = 0;

            foreach (int value in values)
            {
                sum += value;
            }

            return new int[1] { sum };
        } 

        #endregion

        #region - Word Context Map-Reduce Demo -

        static void DoWordContextMapReduceDemo()
        {
            // implements public class Master<K1, V1, K2, V2, V3>
            Master<string, string, string, string, string> master = new Master<string, string, string, string, string>(WordContextMapFunction, WordContextReduceFunction);

            foreach (KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>> result in master.Execute(Utility.GetInputData()))
            {
                var orderedResult = result.Value.OrderByDescending(v => v.Value);

                using (StreamWriter file = new StreamWriter(string.Concat(Utility.DATA_DIRECTORY, string.Format("{0}.csv", result.Key))))
                {
                    foreach (KeyValuePair<string, string> kvp in orderedResult)
                    {
                        file.WriteLine(string.Format("{0},{1}", kvp.Key, kvp.Value));
                    }
                }
            }
        }

        //  implements public delegate IEnumerable<KeyValuePair<K2, V2>> MapFunction(K1 key, V1 value);
        static IList<KeyValuePair<string, string>> WordContextMapFunction(string key, string value)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            string[] words = value.Split(new string[] { " ", "\r\n" }, System.StringSplitOptions.None);

            for(int i = 0; i < words.Length; i++)
            {
                result.Add(
                    new KeyValuePair<string, string>(
                        words[i], string.Format("{0} {1} {2} {3} {4}"
                        , i > 1 ? words[i - 2] : "" 
                        , i > 0 ? words[i - 1] : ""
                        , words[i].ToUpper()
                        , i < words.Length - 1 ? words[i + 1] : ""
                        , i < words.Length - 2 ? words[i + 2] : "")));
            }

            return result;
        }

        // implements public delegate IEnumerable<V3> ReduceFunction(K2 key, IEnumerable<V2> values); 
        static IEnumerable<string> WordContextReduceFunction(string key, IEnumerable<string> values)
        {
            StringBuilder concatenated = new StringBuilder(); ;

            foreach (string value in values)
            {
                concatenated.Append(string.Format("({0}) ", value.Trim()));
            }

            return new string[1] { concatenated.ToString().Trim() };
        }

        #endregion

    }
}