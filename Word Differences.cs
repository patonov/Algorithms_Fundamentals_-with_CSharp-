using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Differences
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringOne = Console.ReadLine();
            var stringTwo = Console.ReadLine();

            var table = new int[stringOne.Length + 1, stringTwo.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;
            }

            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (stringOne[r - 1] == stringTwo[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                    else
                    {
                        table[r, c] = Math.Min(table[r, c - 1], table[r - 1, c]) + 1;
                    }
                }

            }
            Console.WriteLine("Deletions and Insertions: {0}", table[stringOne.Length, stringTwo.Length]);

        }
    }
  }
