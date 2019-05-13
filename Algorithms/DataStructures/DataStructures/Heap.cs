using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS
{
    class Heap
    {
        int[] arr;
        int capacity;
        int currsize;

        private int getParent(int i) => (i - 1) / 2;
        private int getLeftChild(int i) => 2 * i + 1;
        private int getRightChild(int i) => 2 * i + 2;
        private bool withinsize(int i) => i <= currsize;
        public Heap(int capacity)
        {
            arr = new int[capacity];
            currsize = -1;
        }
        public void insert(int val)
        {
            arr[++currsize] = val;
            upheap(currsize);
        }
        private void upheap(int i)
        {
            if (i == 0)
            {
                return;
            }

            if (arr[i] > arr[getParent(i)])
            {
                swap(arr, i, getParent(i));
                upheap(getParent(i));
            }
        }
        private void downheap(int i)
        {
            int maxchild = 0;

            if (!withinsize(getLeftChild(i)) && !withinsize(getRightChild(i)))
            {
                return;
            }
            else if (!withinsize(getLeftChild(i)))
            {
                maxchild = getRightChild(i);
            }
            else if (!withinsize(getRightChild(i)))
            {
                maxchild = getLeftChild(i);
            }
            else
            {
                maxchild = arr[getLeftChild(i)] > arr[getRightChild(i)] ? getLeftChild(i) : getRightChild(i);
            }

            if (arr[i] < arr[maxchild])
            {
                swap(arr, i, maxchild);
                downheap(maxchild);
            }
        }
        private int getMin()
        {
            int val = arr[0];
            return val;
        }
        private int ExtractMin()
        {
            int val = arr[0];
            swap(arr, 0, currsize);
            downheap(0);
            --currsize;
            return val;
        }
        public void changePriority(int i, int val)
        {

        }

        public void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
