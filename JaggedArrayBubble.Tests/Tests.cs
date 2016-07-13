﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JaggedArrayBubble;
using JaggedArrayBubble.Tests;


namespace JaggedArrayBubble.Tests
{
    #region Comparers test data
    
    /// <summary>
    /// Comparing by sum by asc
    /// </summary>
    public class CompareBySumAsc : BubbleSort.ICustomComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
            if (arr1.Sum() > arr2.Sum())
                return 1;
            else if (arr1.Sum() < arr2.Sum())
                return -1;
            else return 0;
        }
    }

    /// <summary>
    /// Comparing by sum by desc
    /// </summary>
    public class CompareBySumDesc : BubbleSort.ICustomComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();
            if (arr1.Sum() > arr2.Sum())
                return -1;
            else if (arr1.Sum() < arr2.Sum())
                return 1;
            else return 0;
        }
    }

    /// <summary>
    /// Comparing by max value by asc
    /// </summary>
    public class CompareByMaxValueAsc : BubbleSort.ICustomComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();

            if (arr1.Max() > arr2.Max())
                return 1;
            else if (arr1.Max() < arr2.Max())
                return -1;
            else return 0;
        }
    }

    /// <summary>
    /// Comparing by max value by desc
    /// </summary>
    public class CompareByMaxValueDesc : BubbleSort.ICustomComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new ArgumentNullException();

            if (arr1.Max() > arr2.Max())
                return -1;
            else if (arr1.Max() < arr2.Max())
                return 1;
            else return 0;
        }
    }

    #endregion

    #region TestData
    public class DataClass
    {
        public static IEnumerable<TestCaseData> TestArraysForCompareBySumAsc
        {
            get
            {
                int[][] arrangeArray = new int[3][];
                arrangeArray[0] = new int[] { 1, 6, 3 };
                arrangeArray[1] = new int[] { 2, 4 };
                arrangeArray[2] = new int[] { 2, 4, 6, 8 };


                int[][] actArray = new int[3][];
                actArray[0] = new int[] { 2, 4 };
                actArray[1] = new int[] { 1, 6, 3 };
                actArray[2] = new int[] { 2, 4, 6, 8 };

                yield return new TestCaseData(arrangeArray, actArray);

            }
        }
        public static IEnumerable<TestCaseData> TestArraysForCompareBySumDesc
        {
            get
            {
                int[][] arrangeArray = new int[3][];
                arrangeArray[0] = new int[] { 1, 6, 3 };
                arrangeArray[1] = new int[] { 2, 4 };
                arrangeArray[2] = new int[] { 2, 4, 6, 8 };


                int[][] actArray = new int[3][];
                actArray[0] = new int[] { 2, 4, 6, 8 };
                actArray[1] = new int[] { 1, 6, 3 };
                actArray[2] = new int[] { 2, 4 };


                yield return new TestCaseData(arrangeArray, actArray);

            }
        }

        public static IEnumerable<TestCaseData> TestArraysForCompareByMaxValueAsc
        {
            get
            {
                int[][] arrangeArray = new int[3][];
                arrangeArray[0] = new int[] { 1, 3, 5 };
                arrangeArray[1] = new int[] { 2, 4 };
                arrangeArray[2] = new int[] { 2, 4, 6, 8 };


                int[][] actArray = new int[3][];
                actArray[0] = new int[] { 2, 4 };
                actArray[1] = new int[] { 1, 3, 5 };
                actArray[2] = new int[] { 2, 4, 6, 8 };

                yield return new TestCaseData(arrangeArray, actArray);

            }
        }
        public static IEnumerable<TestCaseData> TestArraysForCompareByMaxValueDesc
        {
            get
            {
                int[][] arrangeArray = new int[3][];
                arrangeArray[0] = new int[] { 1, 3, 5 };
                arrangeArray[1] = new int[] { 2, 4 };
                arrangeArray[2] = new int[] { 2, 4, 6, 8 };


                int[][] actArray = new int[3][];
                actArray[0] = new int[] { 2, 4, 6, 8 };
                actArray[1] = new int[] { 1, 3, 5 };
                actArray[2] = new int[] { 2, 4 };


                yield return new TestCaseData(arrangeArray, actArray);

            }
        }
    }
    #endregion

    #region Tests
    [TestFixture]
    public class Tests
    {
        [Test, TestCaseSource(typeof(DataClass), "TestArraysForCompareBySumAsc")]
        public void BubbleSortBySumAsc_ArrayAndComparer_SortedArray(int[][] argumentArray, int[][] resultArray)
        {
            CompareBySumAsc compare = new CompareBySumAsc();
            BubbleSort.SortArray(argumentArray, compare);
            Assert.AreEqual(argumentArray, resultArray);
        }

        [Test, TestCaseSource(typeof(DataClass), "TestArraysForCompareBySumDesc")]
        public void BubbleSortBySumDesc_ArrayAndComparer_SortedArray(int[][] argumentArray, int[][] resultArray)
        {
            CompareBySumDesc compare = new CompareBySumDesc();
            BubbleSort.SortArray(argumentArray, compare);
            Assert.AreEqual(argumentArray, resultArray);
        }

        [Test, TestCaseSource(typeof(DataClass), "TestArraysForCompareByMaxValueAsc")]
        public void BubbleSortByMaxValueAsc_ArrayAndComparer_SortedArray(int[][] argumentArray, int[][] resultArray)
        {
            CompareByMaxValueAsc compare = new CompareByMaxValueAsc();
            BubbleSort.SortArray(argumentArray, compare);
            Assert.AreEqual(argumentArray, resultArray);
        }

        [Test, TestCaseSource(typeof(DataClass), "TestArraysForCompareByMaxValueDesc")]
        public void BubbleSortByMaxValueDesc_ArrayAndComparer_SortedArray(int[][] argumentArray, int[][] resultArray)
        {
            CompareByMaxValueDesc compare = new CompareByMaxValueDesc();
            BubbleSort.SortArray(argumentArray, compare);
            Assert.AreEqual(argumentArray, resultArray);
        }
    } 
    #endregion
}
