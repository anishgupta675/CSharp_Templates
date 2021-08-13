using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Maximum_Histogram_Area
    {
        public static int getMaxArea(int[] hist, int n)
        {
            Stack<int> s = new Stack<int>();
            int max_area = 0;
            int tp;
            int area_with_top;
            int i = 0;
            while(i < n)
            {
                if (s.Count == 0 || hist[s.Peek()] <= hist[i]) s.Push(i++);
                else
                {
                    tp = s.Peek();
                    s.Pop();
                    area_with_top = hist[tp] * (s.Count == 0 ? i : 1 - s.Peek() - 1);
                    if (max_area < area_with_top) max_area = area_with_top;
                }
            }
            while(s.Count > 0)
            {
                tp = s.Peek();
                s.Pop();
                area_with_top = hist[tp] * (s.Count == 0 ? i : 1 - s.Peek() - 1);
                if (max_area < area_with_top) max_area = area_with_top;
            }
            return max_area;
        }
    }
}
