using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.Algorithms.Sorting
{
    static class MergeSort
    {
        public static void Merge(int[] arr, int[] aux, int lo, int mid, int hi)
        {
            for (int c = lo; c <= hi; ++c)
            {
                aux[c] = arr[c];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; ++k)
            {
                if (i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (j > hi)
                {
                    arr[k] = aux[i++];
                }
                else if (aux[i] > aux[j])
                {
                    arr[k] = aux[j++];
                }
                else
                {
                    arr[k] = aux[i++];
                }
            }
        }
        public static void Sort(int[] arr, int[] aux, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;

            Sort(arr, aux, lo, mid);
            Sort(arr, aux, mid + 1, hi);
            Merge(arr, aux, lo, mid, hi);
        }
        public static void Sort(int[] arr)
        {
            int[] aux = new int[arr.Length];
            Sort(arr, aux, 0, arr.Length - 1);
        }
    }
}
