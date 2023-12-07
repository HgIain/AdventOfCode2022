using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{

    public class RopeTracker(string fileName)
    {
        private record Offset(int x, int y)
        {
            public static Offset operator +(Offset a, Offset b) => new(a.x + b.x, a.y + b.y);
        }

        private Dictionary<char, Offset> movementLookup = new()
        {
            { 'D', new(0, 1) },
            { 'U', new(0, -1) },
            { 'L', new(-1, 0) },
            { 'R', new(1, 0) }
        };
        private static readonly Offset zeroLocation =  new(0, 0);
        private readonly HashSet<Offset> visitedLocations = new() { { zeroLocation } };

        public int Process(int ropeCount = 2)
        {
            var lines = File.ReadAllLines(fileName);

            var ropeParts = new List<Offset>();

            for(int i = 0; i < ropeCount; i++)
            {
                ropeParts.Add(zeroLocation);
            }

            foreach (var line in lines)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (parts.Length != 2)
                {
                    throw new Exception("Unexpected line");
                }

                var direction = parts[0][0];
                var distance = int.Parse(parts[1]);

                for(int i = 0; i < distance; i++)
                {
                    ropeParts[0] += movementLookup[direction];

                    for (int ropePart = 1; ropePart < ropeCount; ropePart++)
                    {
                        if (Math.Abs(ropeParts[ropePart - 1].x - ropeParts[ropePart].x) <= 1 &&
                            Math.Abs(ropeParts[ropePart - 1].y - ropeParts[ropePart].y) <= 1)
                        {
                            // not far enough away to move the next part
                            break;
                        }
                        
                        // move towards the previous rope part
                        if (ropeParts[ropePart -1].x > ropeParts[ropePart].x)
                        {
                            ropeParts[ropePart] += movementLookup['R'];
                        }
                        else if (ropeParts[ropePart - 1].x < ropeParts[ropePart].x)
                        {
                            ropeParts[ropePart] += movementLookup['L'];
                        }

                        if (ropeParts[ropePart - 1].y > ropeParts[ropePart].y)
                        {
                            ropeParts[ropePart] += movementLookup['D'];
                        }
                        else if (ropeParts[ropePart - 1].y < ropeParts[ropePart].y)
                        {
                            ropeParts[ropePart] += movementLookup['U'];
                        }

                        if (Math.Abs(ropeParts[ropePart - 1].x - ropeParts[ropePart].x) > 1 &&
                            Math.Abs(ropeParts[ropePart - 1].y - ropeParts[ropePart].y) > 1)
                        {
                            throw new Exception("Unexpected distance");
                        }
                    }

                    visitedLocations.Add(ropeParts[^1]);
                }

            }

            int visitedCount = visitedLocations.Count;

            Console.WriteLine($"Answer: {visitedCount}");

            return visitedCount;
        }
    }

}
