﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;
using AlgoAndDS.DataStructures;


namespace AlgoAndDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input1 = Console.ReadLine();
            //int n = Convert.ToInt32(input1);
            //UnionFind uf = new UnionFind(n);

            //string input5 = Console.ReadLine();
            //int l = Convert.ToInt32(input5);

            //for (int i = 0; i < l; ++i)
            //{
            //    string input2 = Console.ReadLine();
            //    var splitinput2 = input2.Split(' ');
            //    int p = Convert.ToInt32(splitinput2[0]);
            //    int q = Convert.ToInt32(splitinput2[1]);
            //    uf.Union(p,q);

            //}

            //string input3 = Console.ReadLine();
            //int m = Convert.ToInt32(input3);

            //for (int i = 0; i < m; ++i)
            //{
            //    string input4 = Console.ReadLine();
            //    var splitinput4 = input4.Split(' ');
            //    int p = Convert.ToInt32(splitinput4[0]);
            //    int q = Convert.ToInt32(splitinput4[1]);
            //    Console.WriteLine(uf.Connected(p, q));
            //}

            //string input = Console.ReadLine();
            //var splitinput = input.Split(' ');
            //int[] arr = new int[splitinput.Length];
            //int index = 0;
            //Program p = new Program();

            //foreach (var str in splitinput)
            //{
            //    arr[index++] = Convert.ToInt32(str);
            //}

            //SelectionSort.Sort(arr);
            //Helper.PrintArray(arr);
            //Console.ReadKey();

            BinarySearchTree theTree = new BinarySearchTree();
            theTree.Put(20, 1);
            theTree.Put(25, 1);
            theTree.Put(45, 1);
            theTree.Put(15, 1);
            theTree.Put(67, 1);
            theTree.Put(43, 1);
            theTree.Put(80, 1);
            theTree.Put(33, 1);
            theTree.Put(67, 1);
            theTree.Put(99, 1);
            theTree.Put(91, 1);
            Console.WriteLine("Inorder Traversal : ");
            theTree.InOrder(theTree.GetRoot());
            Console.WriteLine(" ");
            theTree.NodesInRange(15,35);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}