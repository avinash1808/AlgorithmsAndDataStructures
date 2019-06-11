using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.Algorithms.Graphs;
using AlgoAndDS.DataStructures;

namespace DataStructures.Algorithms.Graphs
{
    class StronglyConnectedComponents
    {
        private DirectedGraph G;
        private int[] id;
        private int count;
        private bool[] visited;

        public StronglyConnectedComponents(DirectedGraph g)
        {
            this.G = g;
            id = new int[G.GetVertices()];
            visited = new bool[G.GetVertices()];
            count = 1;

            TopologicalSort tpsort = new TopologicalSort(G);

            foreach (var vertex in tpsort.Sort())
            {
                if(!visited[vertex])
                {
                    Dfs(G, vertex);
                    ++count;
                }
            }
        }

        public void Dfs(DirectedGraph G, int vertex)
        {
            visited[vertex] = true;
            id[vertex] = count;
            foreach (var adj in G.GetAdjacentNodes(vertex))
            {
                if(!visited[adj])
                    Dfs(G,adj);
            }
        }
    }
}
