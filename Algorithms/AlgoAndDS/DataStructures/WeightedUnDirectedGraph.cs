using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.DataStructures;

namespace AlgoAndDS.DataStructures
{
    class WeightedUnDirectedGraph
    {
        int vertices;
        Dictionary<int, List<WeightedUndirectedEdge>> adj = new Dictionary<int, List<WeightedUndirectedEdge>>();
        public WeightedUnDirectedGraph(int vertices)
        {
            this.vertices = vertices;
        }

        public void AddEdge(WeightedUndirectedEdge edge)
        {
            int oneVertex = edge.Either();
            int otherVertex = edge.Other(oneVertex);

            if (!adj.ContainsKey(oneVertex))
                adj.Add(oneVertex, new List<WeightedUndirectedEdge>());
            if (!adj.ContainsKey(otherVertex))
                adj.Add(otherVertex, new List<WeightedUndirectedEdge>());

            adj[oneVertex].Add(edge);
            adj[otherVertex].Add(edge);
        }

        public IEnumerable<WeightedUndirectedEdge> GetAdjacentEdges(int vertex)
        {
            if (adj.ContainsKey(vertex))
                return adj[vertex];
            else
                return null;
        }
    }
}
