using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_Flood_Fill
    {
        static int M = 8;
        static int N = 8;
        static void floodFillUtil(int[,] screen, int x, int y, int prevC, int newC)
        {
            if (x < 0 || x >= M || y < 0 || y >= N) return;
            if (screen[x, y] != prevC) return;
            floodFillUtil(screen, x + 1, y, prevC, newC);
            floodFillUtil(screen, x - 1, y, prevC, newC);
            floodFillUtil(screen, x, y + 1, prevC, newC);
            floodFillUtil(screen, x, y - 1, prevC, newC);
        }
        static void floodFill(int[,] screen, int x, int y, int newC)
        {
            int prevC = screen[x, y];
            if (prevC == newC) return;
            floodFillUtil(screen, x, y, prevC, newC);
        }
    }
}
