using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, key));
            
        }
        private static int BinarySearch(int[] numbers, int key)
        {
            var left = 0;
            var right = numbers.Length - 1;


            var midPoint = (left + right) / 2;
            var element = numbers[midPoint];

            if (element == key)
            {
                return midPoint;
            }

            if (key > element)
            {
                for (int i = midPoint; i < numbers.Length; i++)
                {
                    if (numbers[i] == key)
                    {
                        return i;
                    }
                }

            }

            if (key < element)
            {
                for (int i = midPoint; i >= 0; i--)
                {
                    if (numbers[i] == key)
                    {
                        return i;
                    }
                }

                return midPoint - 1;
            }

            return -1;

        }
    }
   }
