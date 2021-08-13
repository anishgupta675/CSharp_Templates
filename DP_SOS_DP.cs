using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DP_SOS_DP
    {
        static void SumOverSubsets(int[] a, int n)
        {
            int[] sos = new int[(1 << n)];
            for(int x = 0; x < (1 << n); x++)
            {
                sos[x] = a[0];
                for (int i = x; i > 0; i = (i - 1) & x)
                    sos[x] += a[i];
            }
            for (int i = 0; i < (1 << n); i++)
                Console.Write(sos[i] + " ");
        }
    }
}
