using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    static class QuickSort
    {
        public static int Partition(int[] arr, int lo, int hi)
        {
            int partitionkey = arr[lo];
            int i = lo + 1;
            int j = hi;

            while (i <= j)
            {
                while (i <= j && arr[i] <= partitionkey) ++i;
                while (j >= i && arr[j] >= partitionkey) --j;

                if (i < j)
                {
                    Helper.Swap(arr, i, j);
                }
            }
            if (j < lo) ++j;

            Helper.Swap(arr, lo, j);
            return j;
        }

        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        public static void Sort(int[] arr, int lo, int hi)
        {
            if (lo >= hi) return;

            int p = Partition(arr, lo, hi);

            Sort(arr, lo, p - 1);
            Sort(arr, p + 1, hi);
        }
    }
}
