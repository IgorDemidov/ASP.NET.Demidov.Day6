using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JaggedArray.Library;

namespace JaggedArray.Test
{
    [TestClass]
    public class JaggedArraySorterTest
    {
        public class AscendingSumComparer : IRowComparer
        {
            public int Compare(int[] first, int[] second)
            {

                if ((first == null) || (first.Length == 0))
                {
                    if ((second == null) || (second.Length == 0))
                        return 0;
                    else
                        return -1;
                }
                if ((second == null) || (second.Length == 0))
                    return 1;


                int firstSum = Sum(first);
                int secondSum = Sum(second);

                if (firstSum == secondSum)
                    return 0;
                if (firstSum < secondSum)
                    return -1;
                else return 1;
            }
        }

        public class DescendingSumComparer : IRowComparer
        {
            public int Compare(int[] first, int[] second)
            {
                if ((first == null) || (first.Length == 0))
                {
                    if ((second == null) || (second.Length == 0))
                        return 0;
                    else
                        return 1;
                }
                if ((second == null) || (second.Length == 0))
                    return -1;

                int firstSum = Sum(first);
                int secondSum = Sum(second);

                if (firstSum == secondSum)
                    return 0;
                if (firstSum < secondSum)
                    return 1;
                else return -1;
            }
        }

        private static int Sum(int[] row)
        {
            int sum = 0;
            for (int i = 0; i < row.Length; i++)
            {
                sum += row[i];
            }
            return sum;
        }


        public class AscendingMaxAbsValueComparer : IRowComparer
        {
            public int Compare(int[] first, int[] second)
            {
                if ((first == null) || (first.Length == 0))
                {
                    if ((second == null) || (second.Length == 0))
                        return 0;
                    else
                        return -1;
                }
                if ((second == null) || (second.Length == 0))
                    return 1;

                int maxAbsValueFirst = MaxAbsValue(first);
                int maxAbsValueSecond = MaxAbsValue(second);

                if (maxAbsValueFirst == maxAbsValueSecond)
                    return 0;
                if (maxAbsValueFirst < maxAbsValueSecond)
                    return 1;
                else return -1;
            }
        }

        public class DescendingMaxAbsValueComparer : IRowComparer
        {
            public int Compare(int[] first, int[] second)
            {
                if ((first == null) || (first.Length == 0))
                {
                    if ((second == null) || (second.Length == 0))
                        return 0;
                    else
                        return 1;
                }
                if ((second == null) || (second.Length == 0))
                    return -1;

                int maxAbsValueFirst = MaxAbsValue(first);
                int maxAbsValueSecond = MaxAbsValue(second);

                if (maxAbsValueFirst == maxAbsValueSecond)
                    return 0;
                if (maxAbsValueFirst < maxAbsValueSecond)
                    return 1;
                else return -1;
            }
        }

        private static int MaxAbsValue(int[] row)
        {
            int maxAbsValue = Math.Abs(row[0]);
            for (int i = 1; i < row.Length; i++)
            {
                if (maxAbsValue < Math.Abs(row[i]))
                    maxAbsValue = Math.Abs(row[i]);
            }
            return maxAbsValue;
        }

        bool IsJaggedArraysEqauls(int[][] first, int[][] second)
        {
            if (first.Length != second.Length)
                return false;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] == null)
                {
                    if (second[i] == null)
                        continue;
                    else
                        return false;
                }
                else if (second[i] == null)
                    return false;

                if (first[i].Length != second[i].Length)
                    return false;

                for (int j = 0; j < first[i].Length; j++)
                {
                    if (first[i][j] != second[i][j])
                        return false;
                }
            }
            return true;

        }

        [TestMethod]
        public void Sort_ArrayWithNullAndZeroLengthElements_AscendingSum_IRowComparer()
        {
            int[][] actual = new int[][]{
                new int[]{1, 3, -6, 8, 9},
                new int[]{-2, 4, 3, 1},
                new int[0],
                null,
                null,
                new int[]{1, -3, 6, -8},
                new int[0],
                null,
                new int[]{-15, 5, 4, 17},
            };

            int[][] expected = new int[][]{
                new int[0],
                null,
                null,
                new int[0],
                null,
                new int[]{1, -3, 6, -8},
                new int[]{-2, 4, 3, 1},
                new int[]{-15, 5, 4, 17},
                new int[]{1, 3, -6, 8, 9},
            };

            JaggedArraySorter.Sort(actual, new AscendingSumComparer());

            Assert.IsTrue(IsJaggedArraysEqauls(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullReferenceArgument()
        {
            int[][] actual = null;
            JaggedArraySorter.Sort(actual, new AscendingSumComparer());
        }

        [TestMethod]
        public void Sort_ArrayWithNullAndZeroLengthElements_AscendingSum_Delegate()
        {
            int[][] actual = new int[][]{
                new int[]{1, 3, -6, 8, 9},
                new int[]{-2, 4, 3, 1},
                new int[0],
                null,
                null,
                new int[]{1, -3, 6, -8},
                new int[0],
                null,
                new int[]{-15, 5, 4, 17},
            };

            int[][] expected = new int[][]{
                new int[0],
                null,
                null,
                new int[0],
                null,
                new int[]{1, -3, 6, -8},
                new int[]{-2, 4, 3, 1},
                new int[]{-15, 5, 4, 17},
                new int[]{1, 3, -6, 8, 9},
            };

            JaggedArraySorter.Sort(actual, AscendingSumCompareMethod);

            Assert.IsTrue(IsJaggedArraysEqauls(expected, actual));
        }

        JaggedArraySorter.RowCompareMethodDelegate AscendingSumCompareMethod = (first, second) =>
        {
            if ((first == null) || (first.Length == 0))
            {
                if ((second == null) || (second.Length == 0))
                    return 0;
                else
                    return -1;
            }
            if ((second == null) || (second.Length == 0))
                return 1;


            int firstSum = Sum(first);
            int secondSum = Sum(second);

            if (firstSum == secondSum)
                return 0;
            if (firstSum < secondSum)
                return -1;
            else return 1;
        };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullReferenceArgument_Delegate()
        {
            int[][] actual = null;
            JaggedArraySorter.Sort(actual, AscendingSumCompareMethod);
        }


    }
}
