using DataStructures.Utilities.TreeUtilities;
using DataStructures.Utilities;
using ProjectEuler.Interfaces;
using System.Collections.Generic;

namespace ProjectEuler.Solutions
{
    public class Problem18 : IIntProblem
    {
        private new List<List<int>> _numbers;

        public int Solve()
        {
            List<List<int>> numbers = Utility.MakeListOfListsFromFile(@"C:\Users\dschwie\Desktop\working\projects\ProjectEuler\ProjectEuler\Resources\Problem18\Problem18.txt");

            return BinaryTreeUtility.FindMaxPathSum(numbers);
        }
    }
}
