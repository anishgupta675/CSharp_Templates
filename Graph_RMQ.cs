using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_RMQ
    {
        static int MAX = 500;
        static int[,] lookup = new int[MAX, MAX];
        public class Query
        {
            public int L, R;
            public Query(int L, int R)
            {
                this.L = L;
                this.R = R;
            }
        };
        static void preprocess(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                lookup[i, 0] = i;
            for(int j = 0; (1 << j) <= n; j++)
            {
                for (int i = 0;
                    (i + (1 << j) - 1) < n;
                    i++)
                {
                    if (arr[lookup[i, j - 1]]
                        < arr[lookup[i + (1 << (j - 1)),
                        j - 1]])
                        lookup[i, j] = lookup[i, j - 1];
                    else lookup[i, j]
                            = lookup[i + (1 << (j - 1)), j - 1];
                }
            }
        }
        static int query(int[] arr, int L, int R)
        {
            int j = (int)Math.Log(R - L + 1);
            if (arr[lookup[L, j]]
                <= arr[lookup[R - (1 << j) + 1, j]])
                return arr[lookup[L, j]];
            else return arr[lookup[R - (1 << j) + 1, j]];
        }
        static void RMQ(int[] arr, int n, Query[] q, int m)
        {
            preprocess(arr, n);
            for(int i = 0; i < m; i++)
            {
                int L = q[i].L, R = q[i].R;
                Console.WriteLine("Minimum of [" + L + ", " + R
                    + "] is " + query(arr, L, R));
            }
        }
    }
}
