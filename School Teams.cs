using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlCombs = new string[3];
            var girlsList = new List<string[]>();
            Combine(0, 0, girlCombs, girls, girlsList);

            var boyCombs = new string[2];
            var boysList = new List<string[]>();
            Combine(0, 0, boyCombs, boys, boysList);

            foreach (var currentGirlsComb in girlsList)
            {
                foreach (var currentBoysComb in boysList)
                {
                    Console.WriteLine("{0}, {1}", string.Join(", ", currentGirlsComb), string.Join(", ", currentBoysComb));
                }
            }

        }

        private static void Combine(int cellInx, int elemInx, string[] combs, string[] elements, List<string[]> result)
        {
            if (cellInx >= combs.Length)
            {
                result.Add(combs.ToArray());
                return;
            }

            for (int i = elemInx; i < elements.Length; i++)
            {
                combs[cellInx] = elements[i];
                Combine(cellInx + 1, i + 1, combs, elements, result);
            }
        }

    }
}

