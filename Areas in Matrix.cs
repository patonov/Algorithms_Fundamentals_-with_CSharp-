using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areas_in_Matrix
{
    public class Node
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(n, m);
            visited = new bool[n, m];

            var areas = new SortedDictionary<char, int>();
            var totalAreas = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }

                    DFS(r, c);
                    totalAreas += 1;

                    var key = matrix[r, c];

                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key] += 1;
                    }
                }
            }
            Console.WriteLine($"Areas: {totalAreas}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }
        private static void DFS(int row, int column)
        {

            visited[row, column] = true;

            var children = GetChildren(row, column);

            foreach (var child in children)
            {
                DFS(child.Row, child.Column);
            }

        }

        private static List<Node> GetChildren(int row, int column)
        {
            var children = new List<Node>();

            if (IsInside(row - 1, column) && IsChild(row, column, row - 1, column) && !IsVisited(row - 1, column))
            {
                children.Add(new Node { Row = row - 1, Column = column });
            }

            if (IsInside(row + 1, column) && IsChild(row, column, row + 1, column) && !IsVisited(row + 1, column))
            {
                children.Add(new Node { Row = row + 1, Column = column });
            }

            if (IsInside(row, column - 1) && IsChild(row, column, row, column - 1) && !IsVisited(row, column - 1))
            {
                children.Add(new Node { Row = row, Column = column - 1 });
            }

            if (IsInside(row, column + 1) && IsChild(row, column, row, column + 1) && !IsVisited(row, column + 1))
            {
                children.Add(new Node { Row = row, Column = column + 1 });
            }

            return children;
        }
        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }
        private static bool IsChild(int parentRow, int parentColumn, int childRow, int childColumn)
        {
            return matrix[parentRow, parentColumn] == matrix[childRow, childColumn];
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int columns)
        {
            var result = new char[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                var elements = Console.ReadLine();
                for (int c = 0; c < elements.Length; c++)
                {
                    result[r, c] = elements[c];

                }
            }

            return result;
        }
    }
}
