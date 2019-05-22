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
        

        public KruskalMST(WeightedUnDirectedGraph g)
        {
            this.G = g;
            this.MSTEdges = new Queue<WeightedUndirectedEdge>();
            this.TotalWeight = 0;




        }

        public IEnumerable<WeightedUndirectedEdge> Edges()
        {
            return this.MSTEdges;
        }

    }
}
