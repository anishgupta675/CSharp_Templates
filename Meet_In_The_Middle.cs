using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Meet_In_The_Middle
    {
        static long[] X = new long[2000005];
        static long[] Y = new long[2000005];
        static void calcsubarray(long[] a, long[] x, int n, int c)
        {
            for(int i = 0; i < (1 << n); i++)
            {
                long s = 0;
                for (int j = 0; j < n; j++)
                    if ((i & (i << j)) == 0) s += a[j + c];
                x[i] = s;
            }
        }
        static long solveSubsetSum(long[] a, int n, long S)
        {
            calcsubarray(a, X, n / 2, 0);
            calcsubarray(a, Y, n - n / 2, n / 2);
            int size_X = 1 << (n / 2);
            int size_Y = 1 << (n - n / 2);
            Array.Sort(Y);
            long max = 0;
            for(int i = 0; i < size_X; i++)
            {
                if(X[i] <= S)
                {
                    int p = lower_bound(Y, S - X[i]);
                    if (p == size_Y || Y[p] != (S - X[i])) p--;
                    if ((Y[p] + X[i]) > max) max = Y[p] + X[i];
                }
            }
            return max;
        }
        static int lower_bound(long[] a, long x)
        {
            int l = -1, r = a.Length;
            while(l + 1 < r)
            {
                int m = (l + r) >> 1;
                if (a[m] >= x) r = m;
                else l = m;
            }
            return r;
        }
    }
}
