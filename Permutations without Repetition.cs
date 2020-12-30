using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_without_Repetition
{
    class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        public static void Main()
        {

            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }
        private static void Permute(int cellIndex)
        {
            if (cellIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }
            for (int elementInx = 0; elementInx < elements.Length; elementInx++)
            {
                if (!used[elementInx])
                {
                    used[elementInx] = true;
                    permutations[cellIndex] = elements[elementInx];
                    Permute(cellIndex + 1);
                    used[elementInx] = false;
                }
            }
        }
    }
}
        

