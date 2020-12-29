using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_0_and_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var vector = new int[num];

            Generator01(vector, 0);


        }

        public static void Generator01(int[] vector, int index)
        {

            if (index == vector.Length)
            {
                Console.WriteLine(String.Join("", vector));
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;
                Generator01(vector, index + 1);
            }
        }


    }
}
