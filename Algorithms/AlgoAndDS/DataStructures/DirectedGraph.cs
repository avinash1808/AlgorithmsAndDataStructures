using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class DirectedGraph
    {
        int vertices;
        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

        public int GetVertices() => this.vertices;

        public DirectedGraph(int v)
        {
            this.vertices = v;
        }

        public void AddEdge(int orig, int dest)
        {
            if(!adj.ContainsKey(orig))
                adj.Add(orig,new List<int>());
            if (!adj.ContainsKey(dest))
                adj.Add(dest, new List<int>());

            adj[orig].Add(dest);
            adj[dest].Add(orig);
        }

        public IEnumerable<int> GetAdjacentNodes(int orig)
        {
            if (adj.ContainsKey(orig))
                return adj[orig];
            else
                return null;
        }
    }
}
