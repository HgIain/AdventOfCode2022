using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class SignalStrength(string filename)
    {
        static readonly int[] targetCycles = [20, 60, 100, 140, 180, 220];
        int registerX = 1;
        int cycles = 0;
        int currentTarget = 0;
        int total = 0;

        enum ActionCourse
        {
            Break,
            Continue,
            Noop
        }

        ActionCourse CheckTarget(string line)
        {
            for (int i = 0; i < 2; i++)
            {
                cycles++;

                if (cycles == targetCycles[currentTarget])
                {
                    Console.WriteLine($"Target {currentTarget} reached: {registerX}");
                    total += registerX * cycles;
                    currentTarget++;

                    if (currentTarget == targetCycles.Length)
                    {
                        return ActionCourse.Break; ;
                    }
                }

                if (line == "noop")
                {
                    return ActionCourse.Continue;
                }
            }


            return ActionCourse.Noop;
        }

        public int Process()
        {
            var input = System.IO.File.ReadAllLines(filename);

            foreach(var line in input)
            {
                var action = CheckTarget(line);

                if(action == ActionCourse.Break)
                {
                    break;
                }
                if(action == ActionCourse.Continue)
                {
                    continue;
                }

                var parts = line.Split(' ');

                if(parts.Length != 2)
                {
                    throw new Exception("Unexpected line");
                }

                var registerChange = int.Parse(parts[1]);
                registerX += registerChange;
            }

            Console.WriteLine($"Answer: {total}");

            return total;
        }

        public int ProcessPixels()
        {
            var input = System.IO.File.ReadAllLines(filename);

            string pixels = "";

            foreach (var line in input)
            {
                if (Math.Abs((cycles%40) - registerX) < 2)
                {
                    pixels += '#';
                }
                else
                {
                    pixels += '.';
                }
                cycles++;

                if (line == "noop")
                {
                    continue;
                }

                if (Math.Abs((cycles % 40) - registerX) < 2)
                {
                    pixels += '#';
                }
                else
                {
                    pixels += '.';
                }
                cycles++;

                var parts = line.Split(' ');

                if (parts.Length != 2)
                {
                    throw new Exception("Unexpected line");
                }

                var registerChange = int.Parse(parts[1]);
                registerX += registerChange;
            }

            for(int i = 0; i < 6; i++)
            {
                int start = i * 40;
                int end = (i + 1) * 40;
                Console.WriteLine(pixels[start..end]);
            }


            return total;
        }

    }
}
