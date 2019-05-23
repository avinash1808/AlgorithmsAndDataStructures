using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Common;
using AlgoAndDS.Algorithms.Graphs;
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

            WeightedUnDirectedGraph G = new WeightedUnDirectedGraph(8);
            WeightedUndirectedEdge E1 = new WeightedUndirectedEdge(0,1,10);
            WeightedUndirectedEdge E2 = new WeightedUndirectedEdge(0, 6, 3);
            WeightedUndirectedEdge E3 = new WeightedUndirectedEdge(6, 1, 9);
            WeightedUndirectedEdge E4 = new WeightedUndirectedEdge(1, 3, 5);
            WeightedUndirectedEdge E5 = new WeightedUndirectedEdge(1, 7, 7);
            WeightedUndirectedEdge E6 = new WeightedUndirectedEdge(7, 3, 6);
            WeightedUndirectedEdge E7 = new WeightedUndirectedEdge(0, 2, 13);
            WeightedUndirectedEdge E8 = new WeightedUndirectedEdge(2, 3, 4);
            WeightedUndirectedEdge E9 = new WeightedUndirectedEdge(0, 5, 7);
            WeightedUndirectedEdge E10 = new WeightedUndirectedEdge(2, 5, 13);
            WeightedUndirectedEdge E11 = new WeightedUndirectedEdge(2, 4, 3);
            WeightedUndirectedEdge E12 = new WeightedUndirectedEdge(5, 4, 20);
            WeightedUndirectedEdge E13 = new WeightedUndirectedEdge(3, 4, 2);
            G.AddEdge(E1);
            G.AddEdge(E2);
            G.AddEdge(E3);
            G.AddEdge(E4);
            G.AddEdge(E5);
            G.AddEdge(E6);
            G.AddEdge(E7);
            G.AddEdge(E8);
            G.AddEdge(E9);
            G.AddEdge(E10);
            G.AddEdge(E11);
            G.AddEdge(E12);
            G.AddEdge(E13);
            var mstpath = new PrimsMST(G);
            foreach (var edge in mstpath.Edges())
            {
                var u = edge.Either();
                var v = edge.Other(u);
                Console.Write(u);
                Console.Write("-");
                Console.Write(v);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine(mstpath.Weight());

            Console.ReadKey();
        }
    }
}
