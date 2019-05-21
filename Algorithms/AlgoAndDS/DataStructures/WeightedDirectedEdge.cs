using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class WeightedDirectedEdge : IComparable<WeightedDirectedEdge>
    {
        private int orig;
        private int dest;
        private double weight { get; }

        public int From() => this.orig;

        public int To() => this.dest;

        public double Weight() => this.weight;

        public int CompareTo(WeightedDirectedEdge that)
        {
            if (this.weight < that.Weight()) return -1;
            else if (this.weight > that.Weight()) return 1;
            else return 0;
        }

        public WeightedDirectedEdge(int orig, int dest, int weight)
        {
            this.orig = orig;
            this.dest = dest;
            this.weight = weight;
        }
    }
}
