using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_DFS
    {
        private int V;
        private List<int>[] adj;
        Graph_DFS(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new List<int>();
        }
        void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");
            List<int> vList = adj[v];
            foreach (var n in vList)
                if (!visited[n]) DFSUtil(n, visited);
        }
        void DFS(int v)
        {
            bool[] visited = new bool[V];
            DFSUtil(v, visited);
        }
    }
}
