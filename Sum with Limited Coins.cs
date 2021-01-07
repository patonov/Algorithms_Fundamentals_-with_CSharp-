using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_with_Limited_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var target = int.Parse(Console.ReadLine());

            var sums = CalcSums(numbers);

            Console.WriteLine(sums[target]);

        }
        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var results = new Dictionary<int, int> { { 0, 1 } };

            foreach (var number in numbers)
            {
                var sums = results.Keys.ToArray();
                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!results.ContainsKey(newSum))
                    {
                        results.Add(newSum, 1);
                    }
                    else
                    {
                        results[newSum] += 1;
                    }
                }
            }

            return results;
        }
    }
}
