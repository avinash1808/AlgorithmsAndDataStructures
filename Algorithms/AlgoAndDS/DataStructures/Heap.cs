using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.DataStructures
{
    class Heap
    {
        int[] arr;
        int capacity;
        int currsize;

        private int GetParent(int i) => (i - 1) / 2;
        private int GetLeftChild(int i) => 2 * i + 1;
        private int GetRightChild(int i) => 2 * i + 2;
        private bool Withinsize(int i) => i <= currsize;

        public Heap(int capacity)
        {
            arr = new int[capacity];
            currsize = -1;
        }
        public void Insert(int val)
        {
            arr[++currsize] = val;
            Upheap(currsize);
        }
        private void Upheap(int i)
        {
            if (i == 0)
            {
                return;
            }

            if (arr[i] > arr[GetParent(i)])
            {
                Helper.Swap(arr, i, GetParent(i));
                Upheap(GetParent(i));
            }
        }
        private void Downheap(int i)
        {
            int maxchild = 0;

            if (!Withinsize(GetLeftChild(i)) && !Withinsize(GetRightChild(i)))
            {
                return;
            }
            else if (!Withinsize(GetLeftChild(i)))
            {
                maxchild = GetRightChild(i);
            }
            else if (!Withinsize(GetRightChild(i)))
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
                Downheap(maxchild);
            }
        }
        private int GetMin()
        {
            int val = arr[0];
            return val;
        }
        private int ExtractMin()
        {
            int val = arr[0];
            Helper.Swap(arr, 0, currsize);
            Downheap(0);
            --currsize;
            return val;
        }
        public void ChangePriority(int i, int val)
        {

        }
    }
}
