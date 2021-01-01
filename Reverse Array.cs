using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split();

            for (int left = 0; left < n.Length / 2; left++)
            {
                int right = n.Length - 1 - left;
                Swap(n, left, right);
            }
            Console.WriteLine(string.Join(" ", n));


        }
        public static void Swap(string[] n, int left, int right)
        {
            var temp = n[left];
            n[left] = n[right];
            n[right] = temp;

        }
    }
  }

