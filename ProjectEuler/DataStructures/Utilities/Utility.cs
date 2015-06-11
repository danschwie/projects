using DataStructures.Graphs;
using DataStructures.Trees.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStructures.Utilities
{
    public class Utility
    {
        public delegate List<long> LongListDelegate(long l);

        public static string[] ArrayFromCommaDelimitedFile(string filePath)
        {
            StreamReader reader = File.OpenText(filePath);
            var s = reader.ReadToEnd();
            var arr = s.Split(new char[] { ',' });
            reader.Close();

            return arr;
        }

        public static List<List<int>> MakeListOfListsFromFile(string filePath)
        {
            var line = "";
            var listOfLists = new List<List<int>>();

            using (var reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var numbers = new List<int>(line.Split(' ').Select(i => Convert.ToInt32(i)));
                    listOfLists.Add(numbers);
                }
            }

            return listOfLists;
        }

        public static BinaryTreeNode<int> MakeBinaryTreeFromFile(string filePath)
        {
            var line = "";
            var nodes = new List<List<BinaryTreeNode<int>>>();

            using (var reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var numbers = new List<int>(line.Split(' ').Select(i => Convert.ToInt32(i)));
                    nodes.Add((from n in numbers select new BinaryTreeNode<int>(n)).ToList());
                }
            }

            var rowCount = 0;
            var cellCount = 0;

            foreach (var nodeRow in nodes)
            {
                cellCount = 0;

                foreach (BinaryTreeNode<int> node in nodeRow)
                {
                    node.RowNum = rowCount;
                    node.CellNum = cellCount;

                    if (rowCount != nodes.Count - 1)
                    {

                        node.LeftChild = nodes[rowCount + 1][cellCount];
                        node.RightChild = nodes[rowCount + 1][cellCount + 1];

                        node.LeftChild.RightParent = node;
                        node.RightChild.LeftParent = node;
                    }

                    cellCount++;
                }

                rowCount++;
            }

            return nodes[0][0];
        }

        public static Graph<int> MakeSquareLattice(int numSquaresPerSide)
        {
            var graph = new Graph<int>();

            for (int i = 1; i <= numSquaresPerSide * numSquaresPerSide; i++)
            {
                var v = new Vertex<int>(i);
                graph.Add(v);
            }

            // Example of a 5 x 5 lattice. From s01, a move can be made to either s02 or s06;
            // s01  s02  s03  s04  s05
            // s06  s07  s08  s09  s10
            // s11  s12  s13  s14  s15
            // s16  s17  s18  s19  s20
            // s21  s22  s23  s24  s25
            foreach (Vertex<int> v in graph.Vertices)
            {
                // Only add an edge to an adjacent vertex if we are not on the right side of the lattice;
                if (v.Value % numSquaresPerSide != 0)
                {
                    var adjacentVertex = graph.Vertices.Where(i => i.Value == v.Value + 1).SingleOrDefault();
                    v.AddReachableVertex(adjacentVertex);
                }

                // Attempt to get a reference to the vertex directly below the current vertex. This reference will be null for 
                // vertices in the bottom row.
                var belowVertex = graph.Vertices.Where(i => i.Value == v.Value + numSquaresPerSide).SingleOrDefault();
                
                if (belowVertex != null)
                {
                    v.AddReachableVertex(belowVertex);
                }
            }

            return graph;
        }

        /// <summary>
        /// Returns the number of distinct edges in a n x n grid.
        /// </summary>
        /// <param name="n">The root of the n x n grid.</param>
        /// <returns>The number of distinct edges in a n x n grid.</returns>
        public static int NumDistinctEdges(int n)
        {
            return (2 * n) + (2 * MathLibrary.Utilities.Utility.Square(n));
        }

        public static int[,] TwoDArrayFromFile(string filePath)
        {
            var matrix = new int[20, 20];
            var reader = File.OpenText(filePath);
            var s = reader.ReadLine();
            var rowIndex = 0;

            while (s != null)
            {
                var arr = s.Split(new char[] { ' ' });

                for (int i = 0; i < arr.Length; i++)
                {
                    matrix[rowIndex, i] = arr[i].Substring(0, 1) == "0"
                      ? Convert.ToInt32(arr[i].Substring(1, 1))
                      : Convert.ToInt32(arr[i]);
                }
                rowIndex++;
                s = reader.ReadLine();
            }

            reader.Close();

            return matrix;
        }
    }
}
