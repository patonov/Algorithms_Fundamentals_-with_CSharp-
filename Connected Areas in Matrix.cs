using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connected_Areas_in_Matrix
{
    public class Area
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }


    }

    public class Program
    {

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, columns);
            var visited = new bool[rows, columns];

            var areas = new List<Area>();


            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == '*')
                    {
                        continue;
                    }

                    if (visited[r, c])
                    {
                        continue;
                    }


                    var areaSize = GetAreaSize(matrix, r, c, visited);

                    var area = new Area { Row = r, Col = c, Size = areaSize };
                    areas.Add(area);
                }

            }
            var sorted = areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col).ToList();

            Console.WriteLine("Total areas found: {0}", sorted.Count);

            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", i + 1, area.Row, area.Col, area.Size);
            }



        }
        private static int GetAreaSize(char[,] matrix, int row, int column, bool[,] visited)
        {
            if (Outside(matrix, row, column))
            {
                return 0;
            }

            if (visited[row, column])
            {
                return 0;
            }

            if (matrix[row, column] == '*')
            {
                return 0;
            }

            visited[row, column] = true;

            var areaSize = 1 + GetAreaSize(matrix, row - 1, column, visited) +
                GetAreaSize(matrix, row + 1, column, visited) +
                GetAreaSize(matrix, row, column - 1, visited) +
                GetAreaSize(matrix, row, column + 1, visited);

            return areaSize;




        }

        private static bool Outside(char[,] matrix, int row, int column)
        {
            return row < 0 || column < 0 || row >= matrix.GetLength(0) || column >= matrix.GetLength(1);

        }

        private static char[,] ReadMatrix(int rows, int columns)
        {
            var matrix = new char[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                var columnElements = Console.ReadLine();
                for (int c = 0; c < columnElements.Length; c++)
                {
                    matrix[r, c] = columnElements[c];
                }
            }
            return matrix;
        }
    }
}