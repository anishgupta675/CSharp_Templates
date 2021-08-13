using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DS_Fenwick_Tree
    {
        readonly static int MAX = 1000;
        static int[] BITree = new int[MAX];
        int getSum(int index)
        {
            int sum = 0;
            index = index + 1;
            while(index > 0)
            {
                sum += BITree[index];
                index -= index & (-index);
            }
            return sum;
        }
        public static void updateBIT(int n, int index, int val)
        {
            index = index + 1;
            while(index <= n)
            {
                BITree[index] += val;
                index += index & (-index);
            }
        }
        void constructBITree(int[] arr, int n)
        {
            for (int i = 0; i <= n; i++)
                BITree[i] = 0;
            for (int i = 0; i < n; i++)
                updateBIT(n, i, arr[i]);
        }
    }
}
