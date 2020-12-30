using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_with_Repetition
{
    class Program
    {
        private static string[] elements;

        public static void Main()
        {

            elements = Console.ReadLine().Split();

            Permute(0);

        }
        private static void Permute(int cellIndex)
        {
            if (cellIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(cellIndex + 1);

            var swapped = new HashSet<string> { elements[cellIndex] };

            for (int i = cellIndex + 1; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(cellIndex, i);
                    Permute(cellIndex + 1);
                    Swap(cellIndex, i);
                    swapped.Add(elements[i]);

                }
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

