using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    public partial class SupplyStacks(string filename)
    {
        public string Process(bool multicrate = false)
        {
            var lines = File.ReadAllLines(filename);

            int index;

            var stacks = new Dictionary<int, Stack<char>>();

            // find the blank line delimiting the stacks
            for(index = 0;index < lines.Length;index++)
            {
                if (string.IsNullOrWhiteSpace(lines[index]))
                {
                    break;
                }
            }

            int breakLine = index;

            var numberStacks = int.Parse(lines[index - 1].Split(' ',StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Last());

            // prepopulate the stacks
            for(int i = 0; i < numberStacks; i++)
            {
                stacks.Add(i + 1, new Stack<char>());
            }

            for(index -= 2;index>=0 ; index--)
            {
                string line = lines[index];

                var result = CrateRegex().Matches(line);

                if(result.Count == 0)
                {
                    throw new Exception("Unexpected line");
                }

                foreach(Match match in result.Cast<Match>())
                {
                    if (match.Groups[1].Length != 1)
                    {
                        throw new Exception("Unexpected length");
                    }

                    var stack = ((match.Groups[1].Index - 1) / 4) + 1;

                    stacks[stack].Push(match.Groups[1].Value.First());
                }
            }

            for(index = breakLine + 1; index < lines.Length; index++)
            {
                string line = lines[index];

                var result = NumberRegex().Matches(line);

                if (result.Count != 3)
                {
                    throw new Exception("Unexpected line");
                }

                var moveCount = int.Parse(result[0].Groups[1].Value);
                var fromStack = int.Parse(result[1].Groups[1].Value);
                var toStack = int.Parse(result[2].Groups[1].Value);

                if (fromStack == toStack)
                {
                    throw new Exception("Unexpected move, destination and source are equal");
                }

                if (stacks[fromStack].Count < moveCount)
                {
                    throw new Exception("Unexpected move, from stack too small");
                }

                if (multicrate)
                {
                    var moveCrates = new Stack<char>();
                    for(int i = 0; i < moveCount; i++)
                    {
                        moveCrates.Push(stacks[fromStack].Pop());
                    }
                    for (int i = 0; i < moveCount; i++)
                    {
                        stacks[toStack].Push(moveCrates.Pop());
                    }

                }
                else
                {
                    for (int i = 0; i < moveCount; i++)
                    {
                        stacks[toStack].Push(stacks[fromStack].Pop());
                    }
                }

            }

            string output = string.Empty;

            foreach(var stack in stacks)
            {
                output += stack.Value.Peek();
            }

            Console.WriteLine($"Answer: {output}");

            return output;
        }

        [GeneratedRegex(@"\[([a-zA-Z])\]")]
        private static partial Regex CrateRegex();
        [GeneratedRegex(@"(\d+)")]
        private static partial Regex NumberRegex();
    }

}
