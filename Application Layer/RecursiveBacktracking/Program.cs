using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RecursiveBacktracking
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestMz();
            TestCustomMz();
        }

        private static void TestCustomMz()
        {
            RecursiveBacktracking.Custom.Maze.Mz mz = new Custom.Maze.Mz(5, 5);
            int[,] grid = mz.Generate();
            mz.Print(grid);

        }

        private static void TestMz()
        {
            int row = 3;
            int column = 3;

            int[,] grid = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    grid[i, j] = 0;
                }
            }

            Mz mz = new Mz();
            mz.carvePassage(0, 0, ref grid);

            Print(ref grid);
        }

        private static void Print(ref int[,] grid)
        {
            int xLength = grid.GetLength(0);
            int yLength = grid.GetLength(1);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.WriteLine(grid[i, j]);
                }
            }
        }
    }
}
