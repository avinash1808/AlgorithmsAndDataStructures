using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            int vertices = Convert.ToInt32(input1);


            string input2 = Console.ReadLine();
            int edges = Convert.ToInt32(input2);

            Graph G = new Graph(vertices);

            for (int i = 0; i < edges; ++i)
            {
                string input3 = Console.ReadLine();
                string[] splitinput3 = input3.Split(' ');
                int orig = Convert.ToInt32(splitinput3[0]);
                int dest = Convert.ToInt32(splitinput3[1]);
                G.AddEdge(orig, dest);
            }

            string input4 = Console.ReadLine();
            string[] splitinput4 = input4.Split(' ');
            int source = Convert.ToInt32(splitinput4[0]);
            int destination = Convert.ToInt32(splitinput4[1]);

            Path path = new Path(G, source);

            for (int i = 0; i < vertices; ++i)
            {
                foreach (var currnode in path.GetPathTo(i))
                {
                    Console.Write(currnode);
                    if (currnode != i)
                        Console.Write("-");
                }
                Console.WriteLine();
            }
        }
    }
}
