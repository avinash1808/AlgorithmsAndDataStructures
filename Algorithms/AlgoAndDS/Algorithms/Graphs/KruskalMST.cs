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
        private MinHeap<WeightedUndirectedEdge> minHeap;
        private UnionFind Uf;

        public IEnumerable<WeightedUndirectedEdge> Edges() => this.MSTEdges;
        public double Weight() => this.TotalWeight;

        public KruskalMST(WeightedUnDirectedGraph g)
        {
            this.G = g;
            this.MSTEdges = new Queue<WeightedUndirectedEdge>();
            this.TotalWeight = 0;

            minHeap = new MinHeap<WeightedUndirectedEdge>(this.G.GetVertices() * this.G.GetVertices());
            Uf = new UnionFind(G.GetVertices());

            foreach (var vertex in G.GetVerticesList())
            {
                foreach (var edge in G.GetAdjacentEdges(vertex))
                {
                    minHeap.Insert(edge);
                }
            }

            while (!minHeap.IsEmpty())
            {
                WeightedUndirectedEdge edge = minHeap.ExtractMin();
                int u = edge.Either();
                int v = edge.Other(u);

                if (!Uf.Connected(u,v))
                {
                    MSTEdges.Enqueue(edge);
                    TotalWeight += edge.Weight();
                    Uf.Union(u,v);
                }
            }
        }
    }
}
