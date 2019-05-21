using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class WeightedUndirectedEdge : IComparable<WeightedUndirectedEdge>
    {
        private int orig;
        private int dest;
        private double weight { get; }

        public int Either() => this.orig;

        public int Other(int vertex) => vertex == this.orig ? this.dest: this.orig;

        public double Weight() => this.weight;

        public int CompareTo(WeightedUndirectedEdge that)
        {
            if (this.weight < that.Weight()) return -1;
            else if (this.weight > that.Weight()) return 1;
            else return 0;
        }
        public WeightedUndirectedEdge(int orig, int dest, int weight)
        {
            this.orig = orig;
            this.dest = dest;
            this.weight = weight;
        }
    }
}
