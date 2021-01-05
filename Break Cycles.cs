using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Break_Cycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }
        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string ToStringReversed()
        {
            return $"{this.Second} - {this.First}";
        }
    }

    public class Program
    {
        private static List<Edge> edges;

        private static Dictionary<string, List<string>> graph;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            ProcessInput(n);

            edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList();

            var removedEdges = new List<Edge>();
            var blacklisted = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blacklisted.Contains(edge.ToString()))
                    {
                        continue;
                    }
                    removedEdges.Add(edge);
                    blacklisted.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }
            Console.WriteLine("Edges to remove: {0}", removedEdges.Count);



            foreach (var edge in removedEdges)
            {
                var current = $"{edge.First} - {edge.Second}";

                if (blacklisted.Contains(current))
                {
                    continue;
                }

                Console.WriteLine("{0} - {1}", edge.First, edge.Second);

                var reversed = $"{edge.Second} - {edge.First}";
                blacklisted.Add(reversed);
            }

        }
        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
            return false;
        }
        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var node = parts[0];
                var children = parts[1].Split();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }

        }
    }
}
