﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAndDS.DataStructures
{
    class WeightedDirectedGraph
    {
        int vertices;
        Dictionary<int, List<WeightedDirectedEdge>> adj = new Dictionary<int, List<WeightedDirectedEdge>>();

        public int GetVertices() => this.vertices;
        public IEnumerable<int> GetVerticesList()
        {
            List<int> verticesList = new List<int>();
            for (int i = 0; i < vertices; ++i)
            {
                verticesList.Add(i);
            }

            return verticesList;
        }
        public WeightedDirectedGraph(int vertices)
        {
            this.vertices = vertices;
        }

        public void AddEdge(WeightedDirectedEdge edge)
        {
            int orig = edge.From();

            if (!adj.ContainsKey(orig))
                adj.Add(orig, new List<WeightedDirectedEdge>());

            adj[orig].Add(edge);
        }

        public IEnumerable<WeightedDirectedEdge> GetAdjacentEdges(int vertex)
        {
            if (adj.ContainsKey(vertex))
                return adj[vertex];
            else
                return null;
        }
    }
}
