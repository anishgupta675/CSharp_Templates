﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_Edmond_Karp
    {
        static readonly int V = 6;
        bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;
            List<int> queue = new List<int>();
            queue.Add(s);
            visited[s] = true;
            parent[s] = -1;
            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);
                for(int v = 0; v < V; v++)
                {
                    if(visited[v] == false && rGraph[u, v] > 0)
                    {
                        if(v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Add(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }
            return false;
        }
        int fordFulkerson(int[, ] graph, int s, int t)
        {
            int u, v;
            int[,] rGraph = new int[V, V];
            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];
            int[] parent = new int[V];
            int max_flow = 0;
            while(bfs(rGraph, s, t, parent))
            {
                int path_flow = int.MaxValue;
                for(v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow
                        = Math.Min(path_flow, rGraph[u, v]);
                }
                for(v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }
                max_flow += path_flow;
            }
            return max_flow;
        }
    }
}
