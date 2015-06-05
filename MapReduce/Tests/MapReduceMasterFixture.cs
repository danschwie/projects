//~----------------------------------------------------------------------------
// File:    MapReduceMasterFixture.cs
// Author:  Stephan Brenner (http://www.stephan-brenner.com/)
// Created: 01/21/2007
//----------------------------------------------------------------------------~

using System.Collections.Generic;
using Brenner.MapReduce.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brenner.MapReduce.Tests
{
    [TestClass]
    public class MapReduceMasterFixture
    {
        [TestMethod]
        public void TestCountItems()
        {
            MapReduceMaster<string, string, string, int> master = new MapReduceMaster<string, string, string, int>(Map, Reduce);
            Dictionary<string, string> inputData = new Dictionary<string, string>();
            inputData.Add("logFile1.txt", "Item1\nItem2\nItem3\nItem2");
            inputData.Add("logFile2.txt", "Item2\nItem1\nItem1\nItem2");
            IDictionary<string, IList<int>> outputData = master.Execute(inputData);
            Assert.AreEqual(3, outputData["Item1"][0]);
            Assert.AreEqual(4, outputData["Item2"][0]);
            Assert.AreEqual(1, outputData["Item3"][0]);
        }

        public static void Map(string key, string value, IList<KeyValuePair<string, int>> result)
        {
            string[] items = value.Split('\n');
            foreach (string item in items)
            {
                result.Add(new KeyValuePair<string, int>(item, 1));
            }
        }

        public static void Reduce(string key, IList<int> values, IList<int> result)
        {
            result.Add(0);
            foreach (int value in values)
            {
                result[0] += value;
            }
        }
    }
}