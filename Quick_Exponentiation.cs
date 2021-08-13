using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Quick_Exponentiation
    {
        static int power(int x, int y, int p)
        {
            int res = 1;
            x = x % p;
            if (x == 0) return 0;
            while(y > 0)
            {
                if ((y & 1) != 0) res = (res * x) % p;
                y = y >> 1;
                x = (x * x) % p;
            }
            return res;
        }
    }
}
