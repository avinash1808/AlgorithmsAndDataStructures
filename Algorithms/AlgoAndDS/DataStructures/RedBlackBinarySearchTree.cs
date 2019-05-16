using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class RedBlackBinarySearchTree
    {
        private RedBlackBinarySearchTreeNode root;

        public RedBlackBinarySearchTreeNode GetRoot()
        {
            return root;
        }
        public RedBlackBinarySearchTree()
        {
            root = null;
        }

        public RedBlackBinarySearchTreeNode Insert(int key, int value)
        {
            root = Insert(root, key, value);
            return root;
        }

        public RedBlackBinarySearchTreeNode Insert(RedBlackBinarySearchTreeNode currNode, int key, int value)
        {
            if (currNode == null)
            {
                return new RedBlackBinarySearchTreeNode(key, value, RedBlackBinarySearchTreeNode.Color.Red);
            }
            else if (key.CompareTo(currNode.key) < 0)
            {
                currNode.left = Insert(currNode.left, key, value);
            }
            else if (key.CompareTo(currNode.key) > 0)
            {
                currNode.right = Insert(currNode.right, key, value);
            }
            else
            {
                currNode.value = value;
            }
            currNode.count = CountOf(currNode.left) + CountOf(currNode.right) + 1;

            if (isRed(currNode.right) && !isRed(currNode.left)) currNode = RotateLeftAt(currNode);
            if (isRed(currNode.left) && isRed(currNode.left.left)) currNode = RotateRightAt(currNode);
            if (isRed(currNode.right) && isRed(currNode.left)) Flip(currNode);

            return currNode;
        }

        public int Get(int key)
        {
            return Get(root, key).value;
        }

        public RedBlackBinarySearchTreeNode Get(RedBlackBinarySearchTreeNode currNode, int key)
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

        public bool isRed(RedBlackBinarySearchTreeNode currNode)
        {
            if (currNode == null) return false;
            return currNode.color == RedBlackBinarySearchTreeNode.Color.Red;
        }

        public RedBlackBinarySearchTreeNode RotateLeftAt(RedBlackBinarySearchTreeNode currNode)
        {
            RedBlackBinarySearchTreeNode rightNode = currNode.right;
            rightNode.color = currNode.color;

            currNode.right = rightNode.left;

            rightNode.left = currNode;
            currNode.color = RedBlackBinarySearchTreeNode.Color.Red;
            return rightNode;
        }

        public RedBlackBinarySearchTreeNode RotateRightAt(RedBlackBinarySearchTreeNode currNode)
        {
            RedBlackBinarySearchTreeNode leftNode = currNode.left;
            currNode.left = leftNode.right;
            leftNode.right = currNode;
            return leftNode;
        }

        public void Flip(RedBlackBinarySearchTreeNode currNode)
        {
            currNode.left.color = RedBlackBinarySearchTreeNode.Color.Black;
            currNode.right.color = RedBlackBinarySearchTreeNode.Color.Black;
            currNode.color = RedBlackBinarySearchTreeNode.Color.Red;
        }

        public int Rank(int key)
        {
            RedBlackBinarySearchTreeNode currNode = root;
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

        public void NodesInRange(RedBlackBinarySearchTreeNode currNode, int lo, int hi)
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

        public RedBlackBinarySearchTreeNode Floor(int key)
        {
            return Floor(root, key);
        }

        public RedBlackBinarySearchTreeNode Floor(RedBlackBinarySearchTreeNode currNode, int key)
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
                RedBlackBinarySearchTreeNode newNode = Floor(currNode.right, key);
                if (newNode != null)
                    return newNode;

                return currNode;
            }
        }

        public void InOrder(RedBlackBinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            InOrder(currNode.left);
            Console.Write(currNode.key);
            Console.Write(" ");
            InOrder(currNode.right);
        }

        public void PreOrder(RedBlackBinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            Console.Write(currNode.key);
            Console.Write(" ");
            PreOrder(currNode.left);
            PreOrder(currNode.right);
        }

        public void PostOrder(RedBlackBinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return;

            PostOrder(currNode.left);
            PostOrder(currNode.right);
            Console.Write(currNode.key);
            Console.Write(" ");
        }

        public int CountOf(RedBlackBinarySearchTreeNode currNode)
        {
            if (currNode == null)
                return 0;
            else
                return currNode.count;
        }
    }
}
