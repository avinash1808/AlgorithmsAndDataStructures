using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class BinarySearchTree
    {
        private BinarySearchTreeNode root;

        public BinarySearchTreeNode GetRoot()
        {
            return root;
        }
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTreeNode Put(int key, int value)
        {
            root = Put(root, key, value);
            return root;
        }

        public BinarySearchTreeNode Put(BinarySearchTreeNode currNode, int key, int value)
        {
            if (currNode == null)
            {
                return new BinarySearchTreeNode(key, value);
            }
            else if (key.CompareTo(currNode.key) < 0)
            {
                currNode.left = Put(currNode.left, key, value);
            }
            else if (key.CompareTo(currNode.key) > 0)
            {
                currNode.right = Put(currNode.right, key, value);
            }
            else
            {
                currNode.value = value;
            }
            currNode.count = CountOf(currNode.left) + CountOf(currNode.right) + 1;
            return currNode;
        }

        public int Get(int key)
        {
            return Get(root, key).value;
        }

        public BinarySearchTreeNode Get(BinarySearchTreeNode currNode, int key)
        {
            if (currNode == null)
            {
                return null;
            }
            else if (key.CompareTo(currNode.key) < 0)
            {
                return Get(currNode.left, key);
            }
            else if (key.CompareTo(currNode.key) > 0)
            {
                return Get(currNode.right, key);
            }
            else
            {
                return currNode;
            }
        }

        public int Rank(int key)
        {
            BinarySearchTreeNode currNode = root;
            int rank = 0;

            while (currNode != null)
            {
                if (key.CompareTo(currNode.key) == 0)
                {
                    rank += CountOf(currNode.left);
                    return rank;
                }
                else if (key.CompareTo(currNode.key) < 0)
                {
                    currNode = currNode.left;
                }
                else
                {
                    rank += CountOf(currNode.left) + 1;
                    currNode = currNode.right;
                }
            }

            return rank;
        }

        public int CountInRange(int lo, int hi)
        {
            if (Get(root, hi) != null) return Rank(hi) - Rank(lo) + 1;
            return Rank(hi) - Rank(lo);
        }

        public void NodesInRange(int lo, int hi)
        {
            NodesInRange(root, lo, hi);
        }

        public void NodesInRange(BinarySearchTreeNode currNode, int lo, int hi)
        {
            if (currNode == null) return;
            else if (lo.CompareTo(currNode.key) == 0 || hi.CompareTo(currNode.key) == 0)
            {
                if (lo.CompareTo(currNode.key) == 0)
                {
                    Console.Write(currNode.key);
                    Console.Write(" ");
                    NodesInRange(currNode.right, lo, hi);
                }

                else if (hi.CompareTo(currNode.key) == 0)
                {
                    Console.Write(currNode.key);
                    Console.Write(" ");
                    NodesInRange(currNode.left, lo, hi);
                }
            }
            else if (lo.CompareTo(currNode.key) > 0)
            {
                NodesInRange(currNode.right, lo, hi);
            }
            else if (hi.CompareTo(currNode.key) < 0)
            {
                NodesInRange(currNode.left, lo, hi);
            }
            else
            {
                Console.Write(currNode.key);
                Console.Write(" ");
                NodesInRange(currNode.left, lo, hi);
                NodesInRange(currNode.right, lo, hi);
            }
        }

        public BinarySearchTreeNode Floor(int key)
        {
            return Floor(root, key);
        }
        public BinarySearchTreeNode Floor(BinarySearchTreeNode currNode, int key)
        {
            if (currNode == null)
                return null;

            if (key.CompareTo(currNode.key) == 0)
            {
                return currNode;
            }
            else if (key.CompareTo(currNode.key) < 0)
            {
                return Floor(currNode.left, key);
            }
            else
            {
                BinarySearchTreeNode newNode = Floor(currNode.right, key);
                if (newNode != null)
                    return newNode;

                return currNode;
            }
        }
        public void InOrder(BinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            InOrder(currNode.left);
            Console.Write(currNode.key);
            Console.Write(" ");
            InOrder(currNode.right);
        }

        public void PreOrder(BinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            Console.Write(currNode.key);
            Console.Write(" ");
            PreOrder(currNode.left);
            PreOrder(currNode.right);
        }

        public void PostOrder(BinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            PostOrder(currNode.left);
            PostOrder(currNode.right);
            Console.Write(currNode.key);
            Console.Write(" ");
        }

        public int CountOf(BinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return 0;
            else
                return currNode.count;
        }
    }
}
