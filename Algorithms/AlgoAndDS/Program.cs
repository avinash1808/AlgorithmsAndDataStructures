﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;
using AlgoAndDS.Algorithms.Graphs;
using AlgoAndDS.Algorithms.Sorting;
using AlgoAndDS.DataStructures;


namespace AlgoAndDS
{  
    class Program
    {

        static void Main(string[] args)
        {
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

            //BinarySearchTree theTree = new BinarySearchTree();
            //theTree.Insert(20, 1);
            //theTree.Insert(25, 1);
            //theTree.Insert(45, 1);
            //theTree.Insert(15, 1);
            //theTree.Insert(67, 1);
            //theTree.Insert(43, 1);
            //theTree.Insert(80, 1);
            //theTree.Insert(33, 1);
            //theTree.Insert(67, 1);
            //theTree.Insert(99, 1);
            //theTree.Insert(91, 1);
            //Console.WriteLine("Inorder Traversal : ");
            //theTree.InOrder(theTree.GetRoot());
            //Console.WriteLine(" ");
            //theTree.NodesInRange(15,35);

            //RadixSort a = new RadixSort();
            //string[] teststrings = new string[]{"9973","2834","1263","8531", "8530", "7231","1111","1234", "1112", "1121", "1221", "1311", "1113" };
            //a.MSD(teststrings);
            //Helper.PrintArray(teststrings);
            
            QuickSort3way s1 = new QuickSort3way();
            int[] arr = new int[] {3, 21, -2, 1, 2, 82, 5, 4, 34, 12, 42, 62, 100, 0, 2, 3, 12, 2, 4, 5, 6, 2, 1, 123, 78, 8, 4, -4, -3};
            Helper.PrintArray(arr);
            Console.WriteLine();
            s1.Sort(arr);
            Helper.PrintArray(arr);

            //Trie trie = new Trie();

            //trie.Insert("actor");
            //trie.Insert("art");
            //trie.Insert("artifact");
            //trie.Insert("cat");
            //trie.Insert("catermelon");
            //trie.Insert("cut");
            //trie.Insert("cute");
            //trie.Insert("cutie");
            //trie.Insert("cutter");
            //trie.Insert("cutting");  
            //trie.Insert("kestle");
            //trie.Insert("kit");
            //trie.Insert("kits");
            //trie.Insert("lit");
            //trie.Insert("omlete");
            //trie.Insert("proposal");          
            //trie.Insert("robot");
            //trie.Insert("sandwitch");           
            //trie.Insert("sublet");
            //trie.Insert("subscript");
            //trie.Insert("substitute");
            //trie.Insert("submenu");
            //trie.Insert("subs");
            //trie.Insert("subtle");            
            //trie.Insert("watermelon");

            //Console.WriteLine(trie.Search("cut").ToString());
            //foreach (string str in trie.SearchWild("cute"))
            //{
            //    Console.WriteLine(str);
            //}

            Console.ReadKey();
        }
    }
}
