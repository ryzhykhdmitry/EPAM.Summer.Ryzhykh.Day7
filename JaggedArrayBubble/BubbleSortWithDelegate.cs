using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayBubble
{
    public sealed class BubbleSortWithDelegate
    {
        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="jaggedArray">Array.</param>
        /// <param name="compare">The implementation to use when comparing elements.</param>
        public static void SortArray(int[][] jaggedArray, Func<int[], int[], int> comparer)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = i + 1; j < jaggedArray.Length; j++)
                {                    
                    if (comparer(jaggedArray[i], jaggedArray[j]) == 1)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="jaggedArray">Array</param>
        /// <param name="comparer">Comparer.</param>
        public static void SortArray(int[][] jaggedArray, IComparer<int[]> comparer)
        {
            Func<int[], int[], int> comparerDelegate = comparer.Compare;
            BubbleSortWithDelegate.SortArray(jaggedArray, comparerDelegate);
        }

        /// <summary>
        /// Allows to swap arrays. 
        /// </summary>
        /// <param name="jaggedArray1">First array.</param>
        /// <param name="jaggedArray2">Second array.</param>
        private static void Swap(ref int[] jaggedArray1, ref int[] jaggedArray2)
        {
            var temp = jaggedArray1;
            jaggedArray1 = jaggedArray2;
            jaggedArray2 = temp;
        }        
    }
}

