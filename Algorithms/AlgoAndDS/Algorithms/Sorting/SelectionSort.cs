using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    static class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len - 1; ++i)
            {
                int minIndex = i;

                for (int j = i + 1; j < len; ++j)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Helper.Swap(arr, i, minIndex);
            }
        }
    }
}
