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

        private int GetVisibleTreeCount(int[,] grid)
        {
            int gridWidth = grid.GetLength(0);
            int gridHeight = grid.GetLength(1);

            int total = 0;
            for (int i = 1; i < gridHeight - 1; i++)
                for (int j = 1; j < gridWidth - 1; j++)
                {
                    int treeHeight = grid[i, j];

                    if (treeHeight == 0)
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
            total += (gridHeight + gridWidth - 2) * 2;

            return total;
        }

        private int GetBestScenicScore(int[,] grid)
        {
            int gridWidth = grid.GetLength(0);
            int gridHeight = grid.GetLength(1);

            int bestScore = 0;

            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    int treeHeight = grid[i, j];
                    int treeScore = 1;

                    for (int dir = 0; dir < directions.Length; dir++)
                    {
                        int ni = i + directions[dir].dx;
                        int nj = j + directions[dir].dy;

                        int directionScore = 0;

                        while (ni >= 0 && ni < gridHeight && nj >= 0 && nj < gridWidth)
                        {
                            directionScore++;
                            if (grid[ni, nj] >= treeHeight)
                            {
                                break;
                            }

                            ni += directions[dir].dx;
                            nj += directions[dir].dy;
                        }

                        treeScore *= directionScore;
                    }

                    if(treeScore > bestScore)
                    {
                        bestScore = treeScore;

                    }
                }

            return bestScore;
        }

        public int Process(bool treeScore = false)
        {
            var lines = File.ReadAllLines(fileName);
            int gridWidth = lines[0].Length;
            int gridHeight = lines.Length;

            int[,] grid = new int[gridWidth, gridHeight];

            for (int i= 0; i< gridHeight; i++)
            for(int j=0;j< gridWidth; j++)
            {
                grid[i, j] = lines[i][j] - '0';
            }


            int total;
            if (treeScore)
            {
                total = GetBestScenicScore(grid);
            }
            else
            {
                total = GetVisibleTreeCount(grid);
            }

            Console.WriteLine($"Answer: {total}");
            return total;
        }
    }
}
