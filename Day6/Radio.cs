using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Radio
    {
        public static int ProcessFile(string input, int spanLength = 4)
        {
            var lines = File.ReadAllLines(input);

            int total = 0;

            foreach(var line in lines)
            {
                total += Process(line, spanLength);
            }

            Console.WriteLine($"Answer: {total}");

            return total;
        }

        public static int Process(string input, int spanLength = 4)
        {
            ReadOnlySpan<char> vSpan = input.AsSpan();

            int length = vSpan.Length;

            foreach(char c in vSpan)
            {
                if (c < 'a' || c > 'z')
                {
                    throw new Exception("Unexpected character");
                }
            }

            for(int i= 0; i < length - spanLength; i++)
            {
                var slice = vSpan.Slice(i, spanLength);

                int bitfield = 0;
                bool foundDuplicate = false;

                foreach(char c in slice)
                {
                    int flag = 1 << (c - 'a');

                    if((bitfield & flag) != 0)
                    {
                        foundDuplicate = true;
                        break;
                    }

                    bitfield |= flag;
                }

                if (!foundDuplicate)
                {
                    Console.WriteLine($"Found {slice.ToString()} at index {i+spanLength}");

                    return i + spanLength;
                }
            }
            
            throw new Exception("No match found");
        }

    }
}
