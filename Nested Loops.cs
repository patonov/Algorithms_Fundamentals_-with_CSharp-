using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            var vector = new int[index];

            Generator(vector, 0);


        }

        public static void Generator(int[] vector, int index)
        {

            if (index == vector.Length)
            {
                Console.WriteLine(String.Join(" ", vector));
                return;
            }

            for (int number = 0; number < vector.Length; number++)
            {
                vector[index] = number + 1;
                Generator(vector, index + 1);
            }
        }

    }
}

