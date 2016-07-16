using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayBubble
{
    /// <summary>
    /// Allows to sorg jagged array.
    /// </summary>
    public sealed class BubbleSort
    {

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="jaggedArray">Array.</param>
        /// <param name="compare">The implementation to use when comparing elements.</param>
        public static void SortArray(int[][] jaggedArray, IComparer<int[]> comparer)
        {
            if (comparer == null || jaggedArray == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = i + 1; j < jaggedArray.Length; j++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[j]) == 1)
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
        /// <param name="comparer">Delegate with comparer.</param>
        public static void SortArray(int[][] jaggedArray, Func<int[], int[], int> comparer)
        {                    
            BubbleSort.SortArray(jaggedArray, new Adapter(comparer));
        }

        /// <summary>
        /// Adapter to work with delegates
        /// </summary>
        private class Adapter : IComparer<int[]>
        {
            private Func<int[], int[], int> _comparer;

            public Adapter(Func<int[], int[], int> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(int[] x, int[] y)
            {
                return _comparer(x, y);
            }
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
