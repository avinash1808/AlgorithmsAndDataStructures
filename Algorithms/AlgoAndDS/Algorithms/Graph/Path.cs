using System;
using System.Collections.Generic;
using System.Linq;
using AlgoAndDS;

namespace Algorithms
{
    public class Path
    {
        public Graph G;
        public Dictionary<int, bool> visitedForDfs;
        public Dictionary<int, bool> visitedForBfs;
        int orig;
        public int[] prevNodeInPathForDfs;
        public int[] prevNodeInPathForBfs;
        public int[] distance;

        public Path(Graph g, int orig)
        {
            this.G = g;
            this.visitedForDfs = new Dictionary<int, bool>();
            this.visitedForBfs = new Dictionary<int, bool>();
            this.orig = orig;
            this.prevNodeInPathForDfs = new int[G.GetVertices()];
            this.prevNodeInPathForBfs = new int[G.GetVertices()];
            this.distance = new int[G.GetVertices()];


            for (int i = 0; i < G.GetVertices(); ++i)
            {
                this.visitedForDfs.Add(i, false);
            }
            for (int i = 0; i < G.GetVertices(); ++i)
            {
                this.visitedForBfs.Add(i, false);
            }

            this.Dfs(orig);
            this.Bfs(orig);
        }

        public bool PathExistsTo(int dest) => this.visitedForDfs[dest];

        public int GetMinimumPathLength(int dest) => this.distance[dest];

        public void Dfs(int currnode)
        {
            visitedForDfs[currnode] = true;

            foreach (var adjacentnode in G.GetAdjacentNodes(currnode))
            {
                if (!visitedForDfs[adjacentnode])
                {
                    this.prevNodeInPathForDfs[adjacentnode] = currnode;
                    this.Dfs(adjacentnode);
                }
            }
        }

        public void Bfs(int origin)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(origin);
            visitedForBfs[origin] = true;

            while (queue.Count != 0)
            {
                int currnode = queue.Dequeue();

                foreach (int adjacentnode in G.GetAdjacentNodes(currnode))
                {
                    if (!visitedForBfs[adjacentnode])
                    {
                        queue.Enqueue(adjacentnode);
                        prevNodeInPathForBfs[adjacentnode] = currnode;
                        distance[adjacentnode] = distance[currnode] + 1;
                        visitedForBfs[adjacentnode] = true;
                    }
                }
            }
        }

        public IEnumerable<int> GetAnyPathTo(int dest)
        {
            if (!this.PathExistsTo(dest))
            {
                return null;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(dest);

            if (this.orig == dest)
            {
                return stack;
            }

            while (dest != orig)
            {
                stack.Push(this.prevNodeInPathForDfs[dest]);
                dest = this.prevNodeInPathForDfs[dest];
            }

            return stack;
        }

        public IEnumerable<int> GetShortestLengthPathTo(int dest)
        {
            if (!this.PathExistsTo(dest))
            {
                return null;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(dest);

            if (this.orig == dest)
            {
                return stack;
            }

            while (dest != orig)
            {
                stack.Push(this.prevNodeInPathForBfs[dest]);
                dest = this.prevNodeInPathForBfs[dest];
            }

            return stack;
        }

    }
}
