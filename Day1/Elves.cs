using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Elves(string filename)
    {
        public int Process(int numElves = 1)
        {
            var lines = File.ReadAllLines(filename);

            var elves = new List<int>();
            int currentElf = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(currentElf);
                    currentElf = 0;
                }
                else
                {
                    currentElf += int.Parse(line);
                }
            }

            elves.Add(currentElf);

            int biggestElves = elves.OrderBy(x => -x).Take(numElves).Sum();

            Console.WriteLine($"Answer: {biggestElves}");

            return biggestElves;

        }
    }
}
