using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class BinarySearchTreeNode
    {
        public int key;
        public int value;
        public int count;
        public BinarySearchTreeNode left;
        public BinarySearchTreeNode right;

        public BinarySearchTreeNode(int key, int value)
        {
            this.key = key;
            this.value = value;
            this.count = 1;
        }

        public int CompareTo(BinarySearchTreeNode that)
        {
            return this.key.CompareTo(that.key);
        }
    }
}
