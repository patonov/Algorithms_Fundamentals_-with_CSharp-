using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinominal(n, k));

        }
        public static int GetBinominal(int row, int column)
        {
            if (row <= 0 || row == 1 || column == 0 || column == row)
            {
                return 1;
            }
            return GetBinominal(row - 1, column - 1) + GetBinominal(row - 1, column);

        }
    }
    }

