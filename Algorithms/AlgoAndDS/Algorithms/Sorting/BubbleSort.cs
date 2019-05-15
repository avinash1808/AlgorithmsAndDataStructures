using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.Algorithms.Sorting
{
    static class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len - 1; ++i)
            {
                for (int j = 0; j < len - i - 1; ++j)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        Helper.Swap(arr, j, j + 1);
                    }
                }
            }
        }
    }
}
