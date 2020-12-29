using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            DrawGraph(num);

        }

        public static void DrawGraph(int n)
        {
            if (n <= 0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            DrawGraph(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
    }

