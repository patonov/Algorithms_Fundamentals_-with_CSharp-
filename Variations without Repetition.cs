using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variations_without_Repetition
{
    class Program
    {
        private static string[] elements;

        private static int k;

        private static string[] variations;

        private static bool[] used;

        public static void Main()
        {

            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

            Variate(0);

        }
        private static void Variate(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variate(index + 1);
                    used[i] = false;
                }


            }

        }

    }
}
