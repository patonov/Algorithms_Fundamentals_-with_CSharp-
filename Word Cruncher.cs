using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Cruncher
{
    class Program
    {
        public static string target;
        public static string current;
        public static Dictionary<int, List<string>> wordByLength;
        public static Dictionary<string, int> occurances;
        public static List<string> selectedWords;
        public static HashSet<string> results = new HashSet<string>();

        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordByLength = new Dictionary<int, List<string>>();
            occurances = new Dictionary<string, int>();
            selectedWords = new List<string>();

            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;
                }

                var length = word.Length;

                if (!wordByLength.ContainsKey(length))
                {
                    wordByLength.Add(length, new List<string>());
                }

                if (occurances.ContainsKey(word))
                {
                    occurances[word] += 1;
                }
                else
                {
                    occurances.Add(word, 1);
                }

                wordByLength[length].Add(word);
            }
            current = string.Empty;
            GenerateSolutions(target.Length);

            Console.WriteLine(string.Join(Environment.NewLine, results));

        }
        private static void GenerateSolutions(int length)
        {
            if (length == 0)
            {
                if (current == target)
                {
                    results.Add(string.Join(" ", selectedWords));
                }

                return;
            }

            foreach (var kvp in wordByLength)
            {
                if (kvp.Key > length)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {
                    if (occurances[word] > 0)
                    {
                        current += word;
                        if (IsMatching(target, current))
                        {
                            occurances[word] -= 1;
                            selectedWords.Add(word);
                            GenerateSolutions(length - word.Length);
                            occurances[word] += 1;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }
                        current = current.Remove(current.Length - word.Length, word.Length);
                    }
                }
            }

        }
        private static bool IsMatching(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }

            }
            return true;

        }
    }
    }

