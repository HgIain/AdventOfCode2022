using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class SectionAssignments(string filename)
    {
        public int Process(bool partialOverlaps = false)
        {
            var lines = File.ReadAllLines(filename);

            int overlaps = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(['-',',']).Select(c=>int.Parse(c)).ToList();

                if(parts.Count != 4)
                {
                    throw new Exception("Unexpected number of parts");
                }

                if (partialOverlaps)
                {
                    if ((parts[0] <= parts[2] && parts[1] >= parts[2]) ||
                                               (parts[0] >= parts[2] && parts[0] <= parts[3]))
                    {
                        Console.WriteLine($"Found partial overlap: {line}");
                        overlaps++;
                    }
                }
                else
                {
                    if ((parts[0] <= parts[2] && parts[1] >= parts[3]) ||
                    (parts[0] >= parts[2] && parts[1] <= parts[3]))
                    {
                        Console.WriteLine($"Found overlap: {line}");
                        overlaps++;
                    }
                }

            }

            Console.WriteLine($"Answer: {overlaps}");

            return overlaps;
        }


    }
}
