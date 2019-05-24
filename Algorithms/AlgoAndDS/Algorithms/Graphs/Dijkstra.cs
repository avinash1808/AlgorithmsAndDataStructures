using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlgoAndDS.DataStructures;

namespace AlgoAndDS.Algorithms.Graphs
{
    class Dijkstra
    {
        class Node : IComparable<Node>
        {
            public int key;
            public double value;

            public int CompareTo(Node that)
            {
                if (this.value < that.value) return -1;
                else if (this.value > that.value) return 1;
                else return 0;
            }

            public Node(int k, double v)
            {
                this.key = k;
                this.value = v;
            }
        }

        private WeightedDirectedGraph G;
        private int source;
        private MinHeap<Node> minHeap;
        private double[] DistTo;
        private WeightedDirectedEdge[] EdgeTo;
        

        public double WeightTo(int vertex) => DistTo[vertex];

        public Dijkstra(WeightedDirectedGraph g, int src)
        {
            this.G = g;
            this.source = src;
            this.minHeap = new MinHeap<Node>(this.G.GetVertices() * this.G.GetVertices());
            this.DistTo = new double[this.G.GetVertices()];
            this.EdgeTo = new WeightedDirectedEdge[this.G.GetVertices()];

            foreach (var vertex in this.G.GetVerticesList())
            {               
                if (vertex == this.source) continue;

                DistTo[vertex] = Int32.MaxValue;
                var currNode = new Node(vertex, Int32.MaxValue);
                minHeap.Insert(currNode);
            }

            var srcNode = new Node(this.source, 0);
            minHeap.Insert(srcNode);

            while (!minHeap.IsEmpty())
            {
                var currVertex = minHeap.ExtractMin();

                if (this.G.GetAdjacentEdges(currVertex.key) == null) continue;

                foreach (var adj in this.G.GetAdjacentEdges(currVertex.key))
                {
                    this.RelaxEdge(adj);                  
                }
            }
        }

        public void RelaxEdge(WeightedDirectedEdge edge)
        {
            var fromVertex = edge.From();
            var toVertex = edge.To();

            if (DistTo[toVertex] > DistTo[fromVertex] + edge.Weight())
            {
                DistTo[toVertex] = DistTo[fromVertex] + edge.Weight();
                EdgeTo[toVertex] = edge;
           
                var changedNode = new Node(toVertex,DistTo[toVertex]);

                minHeap.ChangePriority(toVertex,changedNode);
            }
        }

        public IEnumerable<WeightedDirectedEdge> ShortestPathTo(int vertex)
        {
            Stack<WeightedDirectedEdge> shortestPath = new Stack<WeightedDirectedEdge>();
            while (vertex != this.source)
            {
                var edgeto = EdgeTo[vertex];
                shortestPath.Push(edgeto);
                vertex = edgeto.From();
            }

            return shortestPath;
        }
    }
}
