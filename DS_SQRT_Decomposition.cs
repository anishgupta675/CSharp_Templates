using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DS_SQRT_Decomposition
    {
        static readonly int MAXN = 1001;
        static int block_sz;
        static int[] depth = new int[MAXN];
        static int[] parent = new int[MAXN];
        static int[] jump_parent = new int[MAXN];
        static List<int>[] adj = new List<int>[MAXN];
        static void addEdge(int u, int v)
        {
            adj[u].Add(v);
            adj[v].Add(u);
        }
        static int LCANaive(int u, int v)
        {
            if (u == v) return u;
            if(depth[u] > depth[v])
            {
                int t = u;
                u = v;
                v = t;
            }
            v = parent[v];
            return LCANaive(u, v);
        }
        static void dfs(int cur, int prev)
        {
            depth[cur] = depth[prev] + 1;
            parent[cur] = prev;
            if (depth[cur] % block_sz == 0) jump_parent[cur] = parent[cur];
            else jump_parent[cur] = jump_parent[prev];
            for (int i = 0; i < adj[cur].Count; ++i)
                if (adj[cur][i] != prev) dfs(adj[cur][i], cur);
        }
        static int LCASQRT(int u, int v)
        {
            while(jump_parent[u] != jump_parent[v])
            {
                if(depth[u] > depth[v])
                {
                    int t = u;
                    u = v;
                    v = t;
                }
                v = jump_parent[v];
            }
            return LCANaive(u, v);
        }
        static void preprocess(int height)
        {
            block_sz = (int)Math.Sqrt(height);
            depth[0] = -1;
            dfs(1, 0);
        }
    }
}
