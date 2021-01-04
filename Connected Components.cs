using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Components
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line.Split().Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }
                var components = new List<int>();
                DPS(node, components);
                Console.WriteLine($"Connected component: {string.Join(" ", components)}");
            }


        }
        private static void DPS(int node, List<int> components)
        {
            if (visited[node])
            {
                return;
            }
            visited[node] = true;

            foreach (var child in graph[node])
            {
                DPS(child, components);
            }
            components.Add(node);
        }
    }
  }
