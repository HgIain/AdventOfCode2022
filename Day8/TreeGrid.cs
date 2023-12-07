using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class TreeGrid(string fileName)
    {
        private readonly (int dx, int dy)[] directions = [(-1, 0), (0, -1), (1, 0), (0, 1)];

        public int Process()
        {
            var lines = File.ReadAllLines(fileName);

            int total = 0;

            int gridWidth = lines[0].Length;
            int gridHeight = lines.Length;

            int[,] grid = new int[gridWidth, gridHeight];

            for (int i= 0; i< gridHeight; i++)
            for(int j=0;j< gridWidth; j++)
            {
                grid[i, j] = lines[i][j] - '0';
            }

            for(int i = 1; i < gridHeight - 1; i++)
            for(int j = 1; j < gridWidth - 1; j++)
            {
                int treeHeight = grid[i, j];

                if(treeHeight == 0)
                {
                    continue;
                }

                for (int dir = 0; dir < directions.Length; dir++)
                {
                    bool isVisible = true;
                    int ni = i + directions[dir].dx;
                    int nj = j + directions[dir].dy;

                    while (ni >= 0 && ni < gridHeight && nj >= 0 && nj < gridWidth)
                    {
                        if (grid[ni, nj] >= treeHeight)
                        {
                            isVisible = false;
                            break;
                        }

                        ni += directions[dir].dx;
                        nj += directions[dir].dy;
                    }

                    if (isVisible)
                    {
                        total++;
                        break;
                    }
                }
            }

            // add the trees around the edge
            total += (gridHeight + gridWidth - 2)*2;

            Console.WriteLine($"Answer: {total}");
            return total;
        }
    }
}
