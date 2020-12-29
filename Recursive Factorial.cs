using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int result = CalcFact(num);

            Console.WriteLine(result);

        }

        public static int CalcFact(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            return num * CalcFact(num - 1);
        }
    }
    }
