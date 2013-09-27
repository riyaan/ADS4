using Diagnostics;
using System;
using System.Collections.Generic;

namespace Entities.Maze
{
    public class Maze
    {
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int columns;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        private Cell[,] grid;

        public Cell[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private Random rand;

        public Random Rand
        {
            get { return rand; }
            set { rand = value; }
        }

        private MazeStrategy _mazeStrategy;

        public Maze(int rows, int column)
        {
            Rand = new Random((int)DateTime.Now.Ticks);

            Rows = rows;
            Columns = column;

            Size = Rows * Columns;            

            Grid = new Cell[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid[i, j] = new Cell();
                    Grid[i, j].XCoordinate = i;
                    Grid[i, j].YCoordinate = j;
                    Grid[i, j].Adjacents = new List<Cell>();
                }
            }
        }

        public void SetMazeCreationStrategy(MazeStrategy mazeStrategy)
        {
            _mazeStrategy = mazeStrategy;
        }

        public void CreateMaze()
        {
            _mazeStrategy.CreateMaze(Grid[0, 0]);
        }

        public void CreateAdjacents()
        {
            // TODO: Add diagonal adjacents.
            // The adjacents are currently only:
            // towards the left, the top, right, and beneath

            for(int i=0; i<Rows; i++)
            {
                for(int j=0; j<Columns; j++)
                {
                    if ((i - 1) >= 0)
                    {
                        Grid[i, j].Adjacents.Add(grid[i - 1, j]);
                        grid[i - 1, j].AdjacentValue = Rand.Next(Size);
                    }

                    if ((i + 1) < Rows)
                    {
                        Grid[i, j].Adjacents.Add(grid[i + 1, j]);
                        grid[i + 1, j].AdjacentValue = Rand.Next(Size);
                    }

                    if ((j - 1) >= 0)
                    {
                        Grid[i, j].Adjacents.Add(grid[i, j - 1]);
                        grid[i, j - 1].AdjacentValue = Rand.Next(Size);
                    }

                    if ((j + 1) < Columns)
                    {
                        Grid[i, j].Adjacents.Add(grid[i, j + 1]);
                        grid[i, j + 1].AdjacentValue = Rand.Next(Size);
                    }
                 }
            }
        }
        
    }
}