using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class ConnectedComponents
    {
        Graph G;
        Dictionary<int, bool> visited;
        int[] id;
        int count;

        public int GetId(int node) => this.id[node];

        public int GetNumberOfComponents() => this.count;

        public ConnectedComponents(Graph g)
        {
            this.G = g;
            this.visited = new Dictionary<int, bool>();
            this.id = new int[G.GetVertices()];

            for (int i = 0; i < G.GetVertices(); ++i)
            {
                this.visited.Add(i, false);
            }

            for (int i=0;i<G.GetVertices();++i)
            {
                if(!visited[i])
                {
                    Dfs(i);
                    count++;
                }
            }
        }

        public void Dfs(int currnode)
        {
            visited[currnode] = true;
            this.id[currnode] = count;

            foreach (var adjacentnode in G.GetAdjacentNodes(currnode))
            {
                if (!visited[adjacentnode])
                {
                    this.Dfs(adjacentnode);
                }
            }
        }
    }
}
