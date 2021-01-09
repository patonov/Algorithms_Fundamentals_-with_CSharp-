using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Set
{
    class Program
    {
        private static string[] elements;
        
        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(", ").ToArray();

            for (int i = 1; i <= elements.Length; i++)
            {
                combinations = new string[i];

                Combine(0, 0);
            }

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
                Combine(index + 1, i + 1);

            }
        }
    }
}
