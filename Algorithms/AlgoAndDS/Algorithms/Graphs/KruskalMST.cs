using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.DataStructures;

namespace AlgoAndDS.Algorithms.Graphs
{
    class KruskalMST
    {
        private WeightedUnDirectedGraph G;
        private Queue<WeightedUndirectedEdge> MSTEdges;
        private double TotalWeight;

        public IEnumerable<WeightedUndirectedEdge> Edges() => this.MSTEdges;
        public double GetTotalWeight() => this.TotalWeight;

        public KruskalMST(WeightedUnDirectedGraph g)
        {
            this.G = g;
            this.MSTEdges = new Queue<WeightedUndirectedEdge>();
            this.TotalWeight = 0;

            MinHeap<WeightedUndirectedEdge> minHeap = new MinHeap<WeightedUndirectedEdge>(this.G.GetVertices() * this.G.GetVertices());
            UnionFind uf = new UnionFind(G.GetVertices());

            foreach (var vertex in G.GetVerticesList())
            {
                foreach (var edge in G.GetAdjacentEdges(vertex))
                {
                    minHeap.Insert(edge);
                }
            }

            while (!minHeap.isEmpty())
            {
                WeightedUndirectedEdge edge = minHeap.ExtractMin();
                int u = edge.Either();
                int v = edge.Other(u);

                if (!uf.Connected(u,v))
                {
                    MSTEdges.Enqueue(edge);
                    TotalWeight += edge.Weight();
                    uf.Union(u,v);
                }
            }
        }
    }
}
