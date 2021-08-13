using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DS_Sparse_Table
    {
        static readonly int MAX = 500;
        static int[,] table = new int[MAX, MAX];
        static void buildSparseTable(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                table[i, 0] = arr[i];
            for (int j = 0; j <= n; j++)
                for (int i = 0; i <= n - (1 << j); i++)
                    table[i, j] = __gcd(table[i, j - 1],
                        table[i + (1 << (j - 1)),
                        j - 1]);
        }
        static int query(int L, int R)
        {
            int j = (int)Math.Log(R - L + 1);
            return __gcd(table[L, j],
                table[R - (1 << j) + 1, j]);
        }
        static int __gcd(int a, int b)
        {
            return b == 0 ? a : __gcd(b, a % b);
        }
    }
}
