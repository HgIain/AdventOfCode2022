using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Rucksacks(string filename)
    {
        static private int GetPriorityForItem(char item) => item switch
        {
            >= 'A' and <= 'Z' => item - 'A' + 27,
            >= 'a' and <= 'z' => item - 'a' + 1,
            _ => throw new Exception("Unexpected item")
        };

        public int Process()
        {
            var lines = File.ReadAllLines(filename);

            int total = 0;

            foreach (var line in lines)
            {
                string half1 = line[..(line.Length / 2)];
                string half2 = line[(line.Length / 2)..];

                if(half1.Length != half2.Length)
                {
                    throw new Exception("Uneven halves");
                }


                foreach(var c in half1)
                {
                    if(half2.Contains(c))
                    {
                        Console.WriteLine($"Found {c} in both halves");

                        total += GetPriorityForItem(c);
                        break;
                    }
                }
            }

            Console.WriteLine($"Answer: {total}");

            return total;
        }

        public int ProcessGroups()
        {
            var lines = File.ReadAllLines(filename);

            if(lines.Length % 3 != 0)
            {
                throw new Exception("Lines not a multiple of 3");
            }

            int total = 0;

            for(int i=0; i< lines.Length; i+=3)
            {
                foreach (var c in lines[i])
                {
                    if (lines[i+1].Contains(c) &&
                        lines[i+2].Contains(c))
                    {
                        Console.WriteLine($"Found {c} in all three strings");

                        total += GetPriorityForItem(c);
                        break;
                    }
                }
            }

            Console.WriteLine($"Answer: {total}");

            return total;
        }

    }

}
