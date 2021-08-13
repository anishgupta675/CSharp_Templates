using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Offline_Dynamic_Connectivity
    {
        static int root(int[] arr, int i)
        {
            while(arr[i] != i)
            {
                arr[i] = arr[arr[i]];
                i = arr[i];
            }
            return i;
        }
        static void weighted_union(int[] arr, int[] rank, int a, int b)
        {
            int root_a = root(arr, a);
            int root_b = root(arr, b);
            if(rank[rank_a] < rank[root_b])
            {
                arr[root_a] = arr[root_b];
                rank[root_b] += rank[root_a];
            } else
            {
                arr[root_b] = arr[root_a];
                rank[root_a] += rank[root_b];
            }
        }
        static Boolean areSame(int[] arr, int a, int b)
        {
            return (root(arr, a) == root(arr, b));
        }
        static void query(int type, int x, int y, int[] arr, int[] rank)
        {
            if(type == 1)
            {
                if (areSame(arr, x, y) == true) Console.WriteLine("Yes");
                else Console.WriteLine("No");
            } else if(type == 2)
            {
                if (areSame(arr, x, y) == false) weighted_union(arr, rank, x, y);
            }
        }
    }
}
