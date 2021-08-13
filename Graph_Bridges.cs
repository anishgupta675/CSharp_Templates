using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_Bridges
    {
        private int V;
        private List<int>[] adj;
        int time = 0;
        static readonly int NIL = -1;
        Graph_Bridges(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }
        void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }
        void bridgeUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent)
        {
            visited[u] = true;
            disc[u] = low[u] = ++time;
            foreach(int i in adj[u])
            {
                int v = i;
                if (!visited[v])
                {
                    parent[v] = u;
                    bridgeUtil(v, visited, disc, low, parent);
                    low[u] = Math.Min(low[u], low[v]);
                    if (low[v] > disc[u]) Console.WriteLine(u + " " + v);
                }
                else if (v != parent[u]) low[u] = Math.Min(low[u], disc[v]);
            }
        }
        void bridge()
        {
            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int[] parent = new int[V];
            for(int i = 0; i < V; i++)
            {
                parent[i] = NIL;
                visited[i] = false;
            }
            for(int i = 0; i < V; i++)
                if (visited[i] == false) bridgeUtil(i, visited, disc, low, parent);
        }
    }
}
