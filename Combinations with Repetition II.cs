using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations_with_Repetition_II
{
    class Program
    {
        private static string[] elements;

        private static int k;

        private static string[] combinations;

        private static int n;

        static void Main(string[] args)
        {

            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            elements = new string[n];

            for (int i = 0; i < n; i++)
            {
                var temp = (i + 1).ToString();
                elements[i] = temp;
            }


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

