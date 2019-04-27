using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Path
    {
        public Graph G;
        public Dictionary<int, bool> visited;
        int orig;
        public int[] prevNodeInPath;


        public Path(Graph g,int orig)
        {
            this.G = g;
            this.visited = new Dictionary<int, bool>();
            this.prevNodeInPath = new int[G.GetVertices()];
            this.orig = orig;

            for (int i = 0; i < G.GetVertices();++i)
            {
                this.visited.Add(i, false);
            }

            this.Dfs(orig);


        }
        public void Dfs(int currnode)
        {
            visited[currnode] = true;

            foreach (var adjacentnode in G.GetAdjacentNodes(currnode))
            {
                if (!visited[adjacentnode])
                {
                    this.prevNodeInPath[adjacentnode] = currnode;
                    this.Dfs(adjacentnode);
                }
            }
        }

        public bool PathExistsTo(int dest)
        {
            return visited[dest];
        }
        public IEnumerable<int> GetPathTo(int dest)
        {
            if(!this.PathExistsTo(dest))
            {
                return null;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(dest);

            if (this.orig == dest)
            {
                return stack;
            }

            while(dest!=orig)
            {
                stack.Push(this.prevNodeInPath[dest]);
                dest = this.prevNodeInPath[dest];
            }

            return stack;
        }

    }
}
