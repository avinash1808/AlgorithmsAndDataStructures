using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoAndDS.DataStructures;

namespace AlgoAndDS.Algorithms.Graphs
{
    class PrimsMST
    {
        private WeightedUnDirectedGraph G;
        private Queue<WeightedUndirectedEdge> MSTEdges;
        private double TotalWeight;
        private HashSet<int> Visited;
        private MinHeap<WeightedUndirectedEdge> minHeap;

        public IEnumerable<WeightedUndirectedEdge> Edges() => this.MSTEdges;
        public double Weight() => this.TotalWeight;

        public PrimsMST(WeightedUnDirectedGraph g)
        {
            this.G = g;
            this.MSTEdges = new Queue<WeightedUndirectedEdge>();
            this.TotalWeight = 0;

            minHeap = new MinHeap<WeightedUndirectedEdge>(this.G.GetVertices() * this.G.GetVertices());

            var vertex = G.GetVerticesList().ToList().First();
            this.Visit(vertex);

            while (!minHeap.isEmpty())
            {
                WeightedUndirectedEdge edge = minHeap.ExtractMin();
                int u = edge.Either();
                int v = edge.Other(u);

                if (!Visited.Contains(u) || !Visited.Contains(v))
                {
                    MSTEdges.Enqueue(edge);
                    TotalWeight += edge.Weight();
                    var newVertex = Visited.Contains(u) ? v : u;
                    this.Visit(newVertex);
                }

                if (Visited.Count >= G.GetVertices() - 1)
                    break;
            }
        }

        public void Visit(int vertex)
        {
            Visited.Add(vertex);

            foreach (var edge in this.G.GetAdjacentEdges(vertex))
            {
                if(!Visited.Contains(edge.Other(vertex)))
                    minHeap.Insert(edge);
            }

        }
    }
}
