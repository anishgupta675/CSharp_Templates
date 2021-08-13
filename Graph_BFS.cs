using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Graph_BFS
    {
        private int _V;
        LinkedList<int>[] _adj;
        public Graph_BFS(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
                _adj[i] = new LinkedList<int>();
            _V = V;
        }
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);
        }
        public void BFS(int s)
        {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;
            LinkedList<int> queue = new LinkedList<int>();
            visited[s] = true;
            queue.AddLast(s);
            while(queue.Any())
            {
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();
                LinkedList<int> list = _adj[s];
                foreach(var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }
    }
}
