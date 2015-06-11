using DataStructures.Utilities;
using DataStructures.Utilities.TreeUtilities;
using ProjectEuler.Interfaces;
using System.Collections.Generic;

namespace ProjectEuler.Solutions
{
    public class Problem67 : IIntProblem
    {
        private new List<List<int>> _numbers;

        public int Solve()
        {
            List<List<int>> numbers = Utility.MakeListOfListsFromFile(@"C:\Users\dschwie\Desktop\working\projects\ProjectEuler\ProjectEuler\Resources\Problem67\p067_triangle.txt");

            return BinaryTreeUtility.FindMaxPathSum(numbers);
        }
    }
}
