﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;

namespace AlgoAndDS.DataStructures
{
    class MinHeap<T> where T: IComparable<T>
    {
        T[] nodes;
        int[] indexOfKey;
        int capacity;
        int currsize;

        private int getParent(int i) => (i - 1) / 2;
        private int getLeftChild(int i) => 2 * i + 1;
        private int getRightChild(int i) => 2 * i + 2;
        private bool withinsize(int i) => i <= currsize;
        public int GetCapacity() => capacity;
        public int GetMaxIndex() => currsize;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            nodes = new T[capacity];
            indexOfKey = new int[capacity];
            currsize = -1;

            for (int i = 0; i < this.capacity; ++i)
            {
                indexOfKey[i] = i;
            }
        }

        public bool IsEmpty()
        {   
            return currsize == -1;
        }

        public bool Contains(int key)
        {
            int index = indexOfKey[key];
            if (index > currsize || index < 0) return false;
            else return true;
        }

        public void Insert(T nodeToInsert)
        {
            if (this.capacity <= currsize)
                return;
            nodes[++currsize] = nodeToInsert;
            Upheap(currsize);
        }

        public T GetMin()
        {
            T firstNode = nodes[0];
            return firstNode;
        }

        public T ExtractMin()
        {
            T firstNode = nodes[0];
            Helper.Swap(nodes, 0, currsize);
            Helper.Swap(indexOfKey,0,currsize);
            nodes[currsize] = default(T);
            --currsize;
            Downheap(0);

            return firstNode;
        }

        public void ChangePriority(int key, T changedNode)
        {
            if (!Contains(key)) return;

            int i = indexOfKey[key];

            if (i < 0) return;

            nodes[i] = changedNode;

            if (nodes[i].CompareTo(nodes[getParent(i)]) < 0)
            {
                Upheap(i);
            }
            else
            {
                Downheap(i);
            }
        }

        public void Delete(int key)
        {
            if (!Contains(key)) return;

            int i = indexOfKey[key];

            Helper.Swap(nodes, i, currsize);
            Helper.Swap(indexOfKey, i, currsize);
             --currsize;

            if (nodes[i].CompareTo(nodes[getParent(i)]) < 0)
            {
                Upheap(i);
            }
            else
            {
                Downheap(i);
            }
        }

        public int GetMinChildIndex(int i)
        {
            if (withinsize(getRightChild(i)))
            {
                return nodes[getRightChild(i)].CompareTo(nodes[getLeftChild(i)]) < 0 ? getRightChild(i) : getLeftChild(i);
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

            if (nodes[i].CompareTo(nodes[getParent(i)]) < 0)
            {
                Helper.Swap(nodes, i, getParent(i));
                Helper.Swap(indexOfKey, i, getParent(i));
                Upheap(getParent(i));
            }
        }

        private void Downheap(int i)
        {
            int maxChild = GetMinChildIndex(i);

            if (maxChild == -1)
            {
                return;
            }

            if (nodes[maxChild].CompareTo(nodes[i]) < 0)
            {
                Helper.Swap(nodes, i, maxChild);
                Helper.Swap(indexOfKey, i, maxChild);
                Downheap(maxChild);
            }
        }
    }
}
