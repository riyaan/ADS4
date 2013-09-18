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
                }
            }
        }
    }
}