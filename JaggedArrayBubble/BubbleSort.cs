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
        public interface ICustomComparer
        {
            int Compare(int[] arr1, int[] arr2);
        }
        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="arr">Array.</param>
        /// <param name="compare">The implementation to use when comparing elements.</param>
        public static void SortArray(int[][] arr, ICustomComparer compare)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (compare.Compare(arr[i], arr[j]) == 1)
                    {
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Allows to swap arrays. 
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}
