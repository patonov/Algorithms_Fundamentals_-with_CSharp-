using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        public static Dictionary<int, long> memo;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            memo = new Dictionary<int, long>();

            Console.WriteLine(GetFabonacci(n));
        }
        public static long GetFabonacci(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n <= 2)
            {
                return 1;
            }
            var result = GetFabonacci(n - 1) + GetFabonacci(n - 2);
            memo[n] = result;

            return result;
        }
    }
    
}
