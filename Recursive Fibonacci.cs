using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFabonacci(n));


        }
        private static int GetFabonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return GetFabonacci(n - 1) + GetFabonacci(n - 2);
        }
    }
    }

