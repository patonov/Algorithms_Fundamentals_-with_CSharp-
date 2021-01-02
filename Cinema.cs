using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        private static List<string> names;

        private static HashSet<int> lockedSeats;

        private static string[] seats;

        static void Main(string[] args)
        {
            names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            seats = new string[names.Count];

            lockedSeats = new HashSet<int>();

            var line = Console.ReadLine();

            while (line != "generate")
            {
                string[] parts = line.Split(" - ");
                string name = parts[0];
                int position = int.Parse(parts[1]) - 1;
                seats[position] = name;

                lockedSeats.Add(position);

                names.Remove(name);


                line = Console.ReadLine();
            }

            Permute(0);


        }
        public static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var namesIndex = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (lockedSeats.Contains(i))
                    {
                        continue;
                    }

                    seats[i] = names[namesIndex];
                    namesIndex += 1;
                }
                Console.WriteLine(string.Join(" ", seats));

                return;
            }
            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }

        }
        public static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }

    }
    }
