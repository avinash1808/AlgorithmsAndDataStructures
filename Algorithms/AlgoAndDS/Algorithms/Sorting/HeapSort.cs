using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    static class HeapSort
    {
        private static int GetParent(int i) => (i - 1) / 2;
        private static int GetLeftChild(int i) => 2 * i + 1;
        private static int GetRightChild(int i) => 2 * i + 2;
        private static bool Withinsize(int i,int maxIndexSize) => i <= maxIndexSize;

        private static void Downheap(int[] arr, int i, int maxIndexSize)
        {
            int maxchild = 0;

            if (!Withinsize(GetLeftChild(i), maxIndexSize) && !Withinsize(GetRightChild(i), maxIndexSize))
            {
                return;
            }
            else if (!Withinsize(GetLeftChild(i), maxIndexSize))
            {
                maxchild = GetRightChild(i);
            }
            else if (!Withinsize(GetRightChild(i), maxIndexSize))
            {
                maxchild = GetLeftChild(i);
            }
            else
            {
                maxchild = arr[GetLeftChild(i)] > arr[GetRightChild(i)] ? GetLeftChild(i) : GetRightChild(i);
            }

            if (arr[i] < arr[maxchild])
            {
                Helper.Swap(arr, i, maxchild);
                Downheap(arr, maxchild, maxIndexSize);
            }
        }

        public static void Sort(int[] arr)
        {
            int len = arr.Length;
            int maxIndexSize = len - 1;

            for (int i = (len / 2) - 1; i >= 0; --i)
            {
                Downheap(arr, i, maxIndexSize);
            }
            for (int i = len - 1; i >= 0; --i)
            {
                Helper.Swap(arr, 0, i);
                Downheap(arr, 0, i - 1);
            }
        }
    }
}
