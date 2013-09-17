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

        private List<CellProductBase> cells;

        public List<CellProductBase> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Maze(int row, int column)
        {
        }
    }
}