using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));

        }
        private static void BubbleSort(int[] numbers)
        {
            var isSorted = false;
            var sortedElementsCount = 0;

            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length - sortedElementsCount; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(numbers, j - 1, j);
                        isSorted = false;
                    }
                }

            }

        }
        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;

        }
    }
  }
