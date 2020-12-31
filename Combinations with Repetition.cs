using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_with_Repetition
{
    class Program
    {
        private static string[] elements;

        private static int k;

        private static string[] combinations;


        public static void Main()
        {

            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combine(0, 0);

        }
        private static void Combine(int index, int elementsStartIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combine(index + 1, i);

            }
        }
    }
}
