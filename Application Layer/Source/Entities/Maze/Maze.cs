using Diagnostics;
using System;
using System.Collections.Generic;

namespace Entities.Maze
{
    public class Maze
    {        
        public int Rows { get; set; }        
        public int Columns { get; set; }
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public Random Rand { get; set; }        

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
    }
}