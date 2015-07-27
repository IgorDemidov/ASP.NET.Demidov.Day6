using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySorter.Task1.Library
{   
    public static class JaggedArray
    {
        public static void Sort(int[][] jaggedArray, IRowComparer comparer)
        {
            if (jaggedArray==null)
            {
                throw new ArgumentNullException(string.Format("Expecting jaggedArray to be int[][]"));
            }
            BubbleSort(ref jaggedArray, comparer);
        }

        public static void Sort(int[][] jaggedArray, RowCompareMethodDelegate compareMethod)
        {
            IRowComparer comparer = new DelegateCompareProvider(compareMethod);
            Sort(jaggedArray, comparer);
        }
       
        public delegate int RowCompareMethodDelegate(int[] first, int[] second) ;

        private class DelegateCompareProvider : IRowComparer
        {
            RowCompareMethodDelegate delegateCompare;

            public int Compare(int[] first, int[] second)
            {
                return delegateCompare(first, second);
            }

            public DelegateCompareProvider(RowCompareMethodDelegate compareMethod)
            {
                delegateCompare = compareMethod;
            }
        }

        private static void BubbleSort(ref int[][] jaggedArray, IRowComparer comparer)
        {
            for (int j = 0; j < jaggedArray.Length - 1; j++)
            {
                for (int i = 0; i < jaggedArray.Length - j - 1; i++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[i + 1]) == 1)
                    {
                        Swap<int[]>(ref jaggedArray[i], ref jaggedArray[i + 1]);
                    }
                }
            }
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }
    }
}
