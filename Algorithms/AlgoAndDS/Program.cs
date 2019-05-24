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

            WeightedDirectedGraph G = new WeightedDirectedGraph(8);
            WeightedDirectedEdge E1 = new WeightedDirectedEdge(0,1,10);
            WeightedDirectedEdge E2 = new WeightedDirectedEdge(0, 6, 3);
            WeightedDirectedEdge E3 = new WeightedDirectedEdge(6, 1, 9);
            WeightedDirectedEdge E4 = new WeightedDirectedEdge(1, 3, 5);
            WeightedDirectedEdge E5 = new WeightedDirectedEdge(1, 7, 7);
            WeightedDirectedEdge E6 = new WeightedDirectedEdge(7, 3, 6);
            WeightedDirectedEdge E7 = new WeightedDirectedEdge(0, 2, 13);
            WeightedDirectedEdge E8 = new WeightedDirectedEdge(2, 3, 4);
            WeightedDirectedEdge E9 = new WeightedDirectedEdge(0, 5, 7);
            WeightedDirectedEdge E10 = new WeightedDirectedEdge(2, 5, 13);
            WeightedDirectedEdge E11 = new WeightedDirectedEdge(2, 4, 3);
            WeightedDirectedEdge E12 = new WeightedDirectedEdge(5, 4, 20);
            WeightedDirectedEdge E13 = new WeightedDirectedEdge(3, 4, 2);
            WeightedDirectedEdge E21 = new WeightedDirectedEdge(1, 0, 10);
            WeightedDirectedEdge E22 = new WeightedDirectedEdge(6, 0, 3);
            WeightedDirectedEdge E23 = new WeightedDirectedEdge(1, 6, 9);
            WeightedDirectedEdge E24 = new WeightedDirectedEdge(3, 1, 5);
            WeightedDirectedEdge E25 = new WeightedDirectedEdge(7, 1, 7);
            WeightedDirectedEdge E26 = new WeightedDirectedEdge(3, 7, 6);
            WeightedDirectedEdge E27 = new WeightedDirectedEdge(2, 0, 13);
            WeightedDirectedEdge E28 = new WeightedDirectedEdge(3, 2, 4);
            WeightedDirectedEdge E29 = new WeightedDirectedEdge(5, 0, 7);
            WeightedDirectedEdge E30 = new WeightedDirectedEdge(5, 2, 13);
            WeightedDirectedEdge E31 = new WeightedDirectedEdge(4, 2, 3);
            WeightedDirectedEdge E32 = new WeightedDirectedEdge(4, 5, 20);
            WeightedDirectedEdge E33 = new WeightedDirectedEdge(4, 3, 2);
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
            var shortestPath = new Dijkstra(G,0);
            foreach (var edge in shortestPath.ShortestPathTo(4))
            {
                var u = edge.From();
                var v = edge.To();
                Console.Write(u);
                Console.Write("-");
                Console.Write(v);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine(shortestPath.WeightTo(4));

            Console.ReadKey();
        }
    }
}
