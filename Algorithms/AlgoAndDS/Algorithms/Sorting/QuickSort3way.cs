using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.Algorithms.Sorting
{
    class QuickSort3way
    {
        public int Partition(int[] arr, int lo, int hi)
        {
            int pivotval = arr[lo];
            int i=lo+1, t=lo+1, j=hi;

            while (i <= j)
            {
                if (arr[i] < pivotval)
                {
                    Helper.Swap(arr,i,t);
                    ++i;
                    ++t;
                }
                else if (arr[i] == pivotval)
                {
                    ++i;
                }
                else
                {
                    Helper.Swap(arr,i,j);
                    --j;
                }
            }
            Helper.Swap(arr,lo,t-1);
            return t-1;
        }

        public void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length-1);
        }
        public void Sort(int[] arr, int lo, int hi)
        {
            if (lo >= hi) return;

            int pivotIndex = Partition(arr, lo, hi);

            Sort(arr,lo,pivotIndex-1);
            Sort(arr,pivotIndex+1,hi);
        }
    }
}
