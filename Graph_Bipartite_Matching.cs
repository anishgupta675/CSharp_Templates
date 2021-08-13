using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_Bipartite_Matching
    {
        static int M = 6;
        static int N = 6;
        bool bpm(bool[,] bpGraph, int u, bool[] seen, int[] matchR)
        {
            for(int v = 0; v < N; v++)
            {
                if(bpGraph[u, v] && !seen[v])
                {
                    seen[v] = true;
                    if(matchR[v] < 0 || bpm(bpGraph, matchR[v], seen, matchR))
                    {
                        matchR[v] = u;
                        return true;
                    }
                }
            }
            return false;
        }
        int maxBPM(bool[,] bpGraph)
        {
            int[] matchR = new int[N];
            for (int i = 0; i < N; ++i)
                matchR[i] = -1;
            int result = 0;
            for(int u = 0; u < M; u++)
            {
                bool[] seen = new bool[N];
                for (int i = 0; i < N; ++i)
                    seen[i] = false;
                if (bpm(bpGraph, u, seen, matchR)) result++;
            }
            return result;
        }
    }
}
