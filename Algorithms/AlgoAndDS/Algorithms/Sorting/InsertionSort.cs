using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.Algorithms.Sorting
{
    static class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 1; i < len; ++i)
            {
                int j = i;

                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Helper.Swap(arr, j, j - 1);
                    --j;
                }
            }
        }
    }
}
