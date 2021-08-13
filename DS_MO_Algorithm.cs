using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Query
    {
        public int L;
        public int R;
        public Query(int L, int R)
        {
            this.L = L;
            this.R = R;
        }
    }
    class DS_MO_Algorithm
    {
        static void printQuerySums(int[] a, int n, ArrayList q, int m)
        {
            for(int i = 0; i < m; i++)
            {
                int L = ((Query)q[i]).L,
                    R = ((Query)q[i]).R;
                int sum = 0;
                for (int j = L; j <= R; j++)
                    sum += a[j];
                Console.Write("Sum of [" + L + ", " + R + "] is " + sum + "\n");
            }
        }
    }
}
