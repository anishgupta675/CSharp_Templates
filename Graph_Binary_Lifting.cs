using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_Binary_Lifting
    {
        static List<int>[] g;
        static int[,] memo;
        static int[] lev;
        static int log;
        static void dfs(int u, int p)
        {
            memo[u, 0] = p;
            for (int i = 0; i <= log; i++)
                memo[u, i] = memo[memo[u, i - 1], i - 1];
            foreach(int v in g[u])
            {
                if(v != p)
                {
                    lev[v] = lev[u] + 1;
                    dfs(v, u);
                }
            }
        }
        static int lca(int u, int v)
        {
            if(lev[u] < lev[v])
            {
                int temp = u;
                u = v;
                v = temp;
            }
            for (int i = log; i >= 0; i--)
                if ((lev[u] - (int)Math.Pow(2, i)) >= lev[v]) u = memo[u, i];
            if (u == v) return u;
            for(int i = log; i >= 0; i--)
            {
                if(memo[u, i] != memo[v, i])
                {
                    u = memo[u, i];
                    v = memo[v, i];
                }
            }
            return memo[u, 0];
        }
    }
}
