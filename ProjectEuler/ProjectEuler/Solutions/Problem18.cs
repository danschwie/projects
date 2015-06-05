using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using MathLibrary.Utilities;
using MathLibrary;
using MathLibrary.Objects;

namespace ProjectEuler.Solutions
{
    public class Problem18 : IIntProblem
    {
        private int _runningTotal;

        public int Solve()
        {
            var tree = Utility.MakeBinaryTreeFromFile(@"C:\Users\dschwie\Desktop\working\projects\ProjectEuler\ProjectEuler\Resources\Problem18\Problem18.txt");
            Process(tree.Vertices[0]);

            return _runningTotal;
        }

        private void Process(Vertex<int> vertex)
        {
            Console.WriteLine(vertex.Value);
            _runningTotal += vertex.Value;

            if (vertex.ReachableVertices.Count != 0)
            {
                Process(GetChildWithMaxValue(vertex));
            }

            return;
        }

        private Vertex<int> GetChildWithMaxValue(Vertex<int> vertex)
        {
            return vertex.ReachableVertices[0].Value > vertex.ReachableVertices[1].Value 
                ? vertex.ReachableVertices[0]
                : vertex.ReachableVertices[1];
        }
    }
}
