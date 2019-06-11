using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.DataStructures;

namespace AlgoAndDS.Algorithms.Graphs
{
    class TopologicalSort
    {
        public DirectedGraph G;
        private Stack<int> sortedVertices;
        private bool[] visited;

        public TopologicalSort(DirectedGraph g)
        {
            this.G = g;
            sortedVertices = new Stack<int>();
            visited = new bool[G.GetVertices()];

            for (int i = 0; i < G.GetVertices(); ++i)
            {
                if(!visited[i])
                    Dfs(i);
            }

        }

        public void Dfs(int vertex)
        {
            if (visited[vertex]) return;

            visited[vertex] = true;
            foreach (var adj in G.GetAdjacentNodes(vertex))
            {
                if (!visited[adj])
                {
                    Dfs(adj);
                }
            }
            sortedVertices.Push(vertex);
        }

        public IEnumerable<int> Sort()
        {
            return sortedVertices;
        }
    }
}
