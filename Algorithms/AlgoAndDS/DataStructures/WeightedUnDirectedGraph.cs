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

        public int GetVertices() => this.vertices;
        public WeightedUnDirectedGraph(int vertices)
        {
            this.vertices = vertices;
        }

        public IEnumerable<int> GetVerticesList()
        {
            List<int> verticesList= new List<int>();
            for (int i = 0; i < vertices; ++i)
            {
                verticesList.Add(i);
            }

            return verticesList;
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
