using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DS_Disjoint_Set_Union
    {
        public int V, E;
        public Edge[] edge;
        public DS_Disjoint_Set_Union(int nV, int nE)
        {
            V = nV;
            E = nE;
            edge = new Edge[E];
            for (int i = 0; i < E; i++)
                edge[i] = new Edge();
        }
        public class Edge
        {
            public int src, dest;
        }
        class subset
        {
            public int parent;
            public int rank;
        }
        int find(subset[] subsets, int i)
        {
            if (subsets[i].parent != i) subsets[i].parent = find(subsets, subsets[i].parent);
            return subsets[i].parent;
        }
        void Union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);
            if (subsets[xroot].rank < subsets[yroot].rank) subsets[xroot].parent = yroot;
            else if (subsets[yroot].rank < subsets[xroot].rank) subsets[yroot].parent = xroot;
            else
            {
                subsets[xroot].parent = yroot;
                subsets[yroot].rank++;
            }
        }
        int isCycle(DS_Disjoint_Set_Union graph)
        {
            int V = graph.V;
            int E = graph.E;
            subset[] subsets = new subset[V];
            for(int v = 0; v < V; v++)
            {
                subsets[v] = new subset();
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }
            for(int e = 0; e < E; e++)
            {
                int x = find(subsets, graph.edge[e].src);
                int y = find(subsets, graph.edge[e].dest);
                if (x == y) return 1;
                Union(subsets, x, y);
            }
            return 0;
        }
    }
}
