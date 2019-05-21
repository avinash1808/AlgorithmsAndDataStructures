using System.Collections.Generic;

namespace AlgoAndDS.DataStructures
{
    public class Graph
    {
        int vertices;
        Dictionary<int, List<int>> adj;

        public int GetVertices() => this.vertices;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            this.adj = new Dictionary<int, List<int>>();

            for (int i = 0; i < this.vertices;++i)
            {
                this.adj.Add(i, new List<int>());
            }
        }
        public void AddEdge(int orig, int dest)
        {
            this.adj[orig].Add(dest);
            this.adj[dest].Add(orig);
        }
        public IEnumerable<int> GetAdjacentNodes(int v)
        {
            return this.adj[v];
        }
    }
}
