using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Utilities.TreeUtilities
{
    public class BinaryTreeUtility
    {
        /// <summary>
        /// Dynamic programming. 
        /// Total # of nodes in a tree of depth n = Utility.TriangleNumber(n) = (n * (n + 1)) / 2.
        /// Since each node must be visited exactly once, the runtime complexity of this approach is O(n^2).
        /// A brute force approach on the other hand requires that every path is checked. Since a binary tree of depth n 
        /// has 2^n-1 paths, the runtime complexity of a brute force approach is O(2^n).
        /// 
        /// From http://www.codechef.com/wiki/tutorial-dynamic-programming
        /// Dynamic programming (usually referred to as DP ) is a very powerful technique to solve a particular class of problems. 
        /// It demands very elegant formulation of the approach and simple thinking and the coding part is very easy. 
        /// The idea is very simple, If you have solved a problem with the given input, then save the result for future reference, so as to 
        /// avoid solving the same problem again.. shortly 'Remember your Past' :) .  
        /// If the given problem can be broken up in to smaller sub-problems and these smaller subproblems are in turn divided in to still-smaller 
        /// ones, and in this process, if you observe some over-lappping subproblems, then its a big hint for DP. Also, the optimal solutions 
        /// to the subproblems contribute to the optimal solution of the given problem ( referred to as the Optimal Substructure Property ).
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

                    // Dynamic programming component.
                    // Remember max sum to this node by updating the node's value so we don't need to recompute the entire path for its' children.
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
