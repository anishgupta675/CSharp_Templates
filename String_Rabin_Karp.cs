using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class String_Rabin_Karp
    {
        public readonly static int d = 256;
        static void search(String pat, String txt, int q)
        {
            int M = pat.Length;
            int N = pat.Length;
            int i, j;
            int p = 0;
            int t = 0;
            int h = 1;
            for (i = 0; i < M - 1; i++)
                h = (h * d) % q;
            for(i = 0; i < M; i++)
            {
                p = (d * p + pat[i]) % q;
                t = (d * t + txt[i]) % q;
            }
            for(i = 0; i <= N - M; i++)
            {
                if(p == t)
                {
                    for (j = 0; j < M; j++)
                        if (txt[i + j] != pat[j]) break;
                    if (j == M) Console.WriteLine("Pattern found at index " + i);
                }
                if(i < N - M)
                {
                    t = (d * (t - txt[i] * h) + txt[i + M]) % q;
                    if (t < 0) t = (t + q);
                }
            }
        }
    }
}
