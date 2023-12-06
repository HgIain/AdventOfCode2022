using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class RockPaperScissors(string filename)
    {
        public Dictionary<char, Dictionary<char, int>> MoveLookups { get; } = new() 
        {
            { 'A', new ()
            {
                { 'X', 3 },
                { 'Y', 6 },
                { 'Z', 0 }
            }
            },
            { 'B', new ()
            {
                { 'X', 0 },
                { 'Y', 3 },
                { 'Z', 6 }
            }
            },
            { 'C', new ()
            {
                { 'X', 6 },
                { 'Y', 0 },
                { 'Z', 3 }
            }
            },
        };
        public Dictionary<char, Dictionary<char, char>> CounterLookups { get; } = new()
        {
            { 'A', new ()
            {
                { 'X', 'Z' },
                { 'Y', 'X' },
                { 'Z', 'Y' }
            }
            },
            { 'B', new ()
            {
                { 'X', 'X' },
                { 'Y', 'Y' },
                { 'Z', 'Z' }
            }
            },
            { 'C', new ()
            {
                { 'X', 'Y' },
                { 'Y', 'Z' },
                { 'Z', 'X' }
            }
            },
        };
        public readonly Dictionary<char, int> MoveScores = new()
        {
            { 'X', 1 },
            { 'Y', 2 },
            { 'Z', 3 }
        };

        private int GetScoreForBattle(char opponent, char me)
        {
            int score = MoveLookups[opponent][me]; 
            score += MoveScores[me];
            return score;
        }

        private int GetScoreForBattlev2(char opponent, char winStatus)
        {
            char myMove = CounterLookups[opponent][winStatus];
            int score = MoveLookups[opponent][myMove];
            score += MoveScores[myMove];
            return score;
        }

        public int Process(bool version2 = false)
        {
            var lines = File.ReadAllLines(filename);

            int score = 0;

            foreach (var line in lines)
            {
                var battle = line.Split(' ').Select(c=>c.First()).ToList();

                if (version2)
                {
                    score += GetScoreForBattlev2(battle[0], battle[1]);

                }
                else
                {
                    score += GetScoreForBattle(battle[0], battle[1]);
                }
            }

            Console.WriteLine($"Answer: {score}");

            return score;

        }
    }
}
