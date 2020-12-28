using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = CalcSum(num, 0);

            Console.WriteLine(result);

        }

        public static int CalcSum(int[] numArr, int index)
        {
            if (index >= numArr.Length)
            {
                return 0;
            }
            return numArr[index] + CalcSum(numArr, index + 1);
        }
    }
    }

