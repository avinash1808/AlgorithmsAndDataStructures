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
        int[] nodes;
        int capacity;
        int currsize;

        private int getParent(int i) => (i - 1) / 2;
        private int getLeftChild(int i) => 2 * i + 1;
        private int getRightChild(int i) => 2 * i + 2;
        private bool withinsize(int i) => i <= currsize;
        public int GetCapacity() => capacity;
        public int GetMaxIndex() => currsize;

        public Heap(int capacity)
        {
            this.capacity = capacity;
            nodes = new int[capacity];
            currsize = -1;
        }

        public void Insert(int val)
        {
            if (this.capacity <= currsize)
                return;
            nodes[++currsize] = val;
            Upheap(currsize);
        }

        public int GetMin()
        {
            int val = nodes[0];
            return val;
        }

        public int ExtractMin()
        {
            int val = nodes[0];
            Helper.Swap(nodes, 0, currsize);
            --currsize;
            Downheap(0);

            return val;
        }

        public void ChangePriority(int i, int val)
        {
            if (i < 0) return;

            nodes[i] = val;

            if (nodes[i] > nodes[getParent(i)])
            {
                Upheap(i);
            }
            else
            {
                Downheap(i);
            }
        }

        public void Delete(int i)
        {
            Helper.Swap(nodes, i, currsize);
            --currsize;

            if (nodes[i] > nodes[getParent(i)])
            {
                Upheap(i);
            }
            else
            {
                Downheap(i);
            }
        }

        public int GetMaxChildIndex(int i)
        {
            if (withinsize(getRightChild(i)))
            {
                return nodes[getRightChild(i)] > nodes[getLeftChild(i)] ? getRightChild(i) : getLeftChild(i);
            }
            else if (withinsize(getLeftChild(i)))
            {
                return getLeftChild(i);
            }
            else
            {
                return -1;
            }
        }

        private void Upheap(int i)
        {
            if (i <= 0)
            {
                return;
            }

            if (nodes[i] > nodes[getParent(i)])
            {
                Helper.Swap(nodes, i, getParent(i));
                Upheap(getParent(i));
            }
        }

        private void Downheap(int i)
        {
            int maxChild = GetMaxChildIndex(i);

            if (maxChild == -1)
            {
                return;
            }

            if (nodes[maxChild] > nodes[i])
            {
                Helper.Swap(nodes, i, maxChild);
                Downheap(maxChild);
            }
        }
    }
}
