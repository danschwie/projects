using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Utilities.TreeUtilities
{
    public class BinaryTreeUtilities
    {
        /// <summary>
        /// Dynamic programming. 
        /// Total # of nodes in a tree of depth n = Utility.TriangleNumber(n) = (n * (n + 1)) / 2.
        /// Since each node must be visited exactly once, the runtime complexity of this approach is O(n^2).
        /// A brute force approach on the other hand requires that every path is checked. Since a binary tree of depth n 
        /// has 2^n-1 paths, the runtime complexity of a brute force approach is O(2^n).
        /// </summary>
        public static int FindMaxPathSum(List<List<int>> numbers)
        {
            var maxSumToParent = 0;

            for (int row = 0; row < numbers.Count; row++)
            {
                for (int cell = 0; cell < numbers[row].Count; cell++)
                {
                    if (GetLeftParent(row, cell, numbers) != -1)
                    {
                        maxSumToParent = GetLeftParent(row, cell, numbers);
                    }

                    if (GetRightParent(row, cell, numbers) != -1)
                    {
                        maxSumToParent = Math.Max(maxSumToParent, GetRightParent(row, cell, numbers));
                    }

                    numbers[row][cell] += maxSumToParent;
                }
            }

            return numbers[numbers.Count - 1].Max();
        }

        #region - Private Methods -

        private static int GetLeftParent(int row, int cell, List<List<int>> numbers)
        {
            // Node is on the far left edge of the tree and therefore has no left parent.
            if (cell == 0)
            {
                return -1;
            }
            else
            {
                return numbers[row - 1][cell - 1];
            }
        }

        private static int GetRightParent(int row, int cell, List<List<int>> numbers)
        {
            // Node is on the far right edge of the tree and therefore has no right parent.
            if ((row == 0 && cell == 0) || cell == numbers[row].Count - 1)
            {
                return -1;
            }
            else
            {
                return numbers[row - 1][cell];
            }
        } 

        #endregion
    }
}
