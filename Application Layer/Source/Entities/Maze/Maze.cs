using Diagnostics;
using Entities.Cell;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
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

        private CellProductBase[,] grid;

        public CellProductBase[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public Maze(int rows, int column)
        {
            Rows = rows;
            Columns = column;

            Size = Rows * Columns;

            Grid = new CellProductBase[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid[i, j] = CellFactory.MakeCell(CELL_TYPE.OPEN);
                    Grid[i, j].XCoordinate = i;
                    Grid[i, j].YCoordinate = j;
                    Grid[i, j].Adjacents = new List<CellProductBase>();
                }
            }
        }

        public void CreateAdjacents()
        {
            for(int i=0; i<Rows; i++)
            {
                for(int j=0; j<Columns; j++)
                {
                    if ((i - 1) >= 0)                                         
                        Grid[i,j].Adjacents.Add(grid[i - 1, j]);                    

                    if((i + 1) < Rows)
                        Grid[i, j].Adjacents.Add(grid[i + 1, j]);

                    if((j - 1) >= 0)
                        Grid[i, j].Adjacents.Add(grid[i, j - 1]);

                    if((j + 1) < Columns)
                        Grid[i, j].Adjacents.Add(grid[i, j + 1]);
                 }
            }
        }
    }
}