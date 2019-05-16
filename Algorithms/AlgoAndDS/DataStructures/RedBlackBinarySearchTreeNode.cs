using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class RedBlackBinarySearchTreeNode : IComparable<RedBlackBinarySearchTreeNode>
    {
        public int key;
        public int value;
        public int count;
        public Color color;
        public RedBlackBinarySearchTreeNode left;
        public RedBlackBinarySearchTreeNode right;

        public enum Color
        {
            Black = 0,
            Red = 1
        }

        public RedBlackBinarySearchTreeNode(int key, int value, Color color)
        {
            this.key = key;
            this.value = value;
            this.count = 1;
            this.color = color;
        }

        public int CompareTo(RedBlackBinarySearchTreeNode that)
        {
            return this.key.CompareTo(that.key);
        }

        
    }
}
