using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomComparers;

namespace JaggedArrayBubble
{
    public sealed class BubbleSortWithDelegate
    {
        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="arr">Array.</param>
        /// <param name="compare">The implementation to use when comparing elements.</param>
        public static void SortArray(int[][] arr, Delegate comparerDelegate)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    var result = comparerDelegate.DynamicInvoke(arr[i], arr[j]);
                    if ((int)result == 1)
                    {
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Sort jagged array.
        /// </summary>
        /// <param name="arr">Array</param>
        /// <param name="comparer">Comparer.</param>
        public static void SortArray(int[][] arr, ICustomComparer comparer)
        {
            ComparersDelegate comparerDelegate = comparer.Compare;
            BubbleSortWithDelegate.SortArray(arr, comparerDelegate);
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

        private delegate int ComparersDelegate(int[] arr1, int[] arr2);
    }
}

