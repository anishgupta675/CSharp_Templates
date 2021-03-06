using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DP_Coin_Change
    {
        static int count(int[] S, int m, int n)
        {
            int[] table = new int[n + 1];
            table[0] = 1;
            for (int i = 0; i < m; i++)
                for (int j = S[i]; j <= n; j++)
                    table[j] += table[j - S[i]];
            return table[n];
        }
    }
}
