using Diagnostics;
using System;
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

        private Cell[,] grid;

        public Cell[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private bool endReached;

        public bool EndReached
        {
            get { return endReached; }
            set { endReached = value; }
        }

        private Random rand;

        public Random Rand
        {
            get { return rand; }
            set { rand = value; }
        }

        private Stack<Cell> _stack;

        public Maze(int rows, int column)
        {
            _stack = new Stack<Cell>();

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

        public void CreateAdjacents()
        {
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

        // TODO: Give the recursive backtracker algorithm a try
        // http://en.wikipedia.org/wiki/Maze_generation_algorithm
        public void FindEnd(Cell c)
        {
            // if all adjacents has been visited quit
            if (c.HasAllAdjacentsBeenVisited())
            {
                Diagnostics.Logger.Instance.Log("All adjacents for this cell has been visited. Can't go anywhere.");
                Diagnostics.Logger.Instance.Log(String.Format("End position: Cell[{0}, {1}]", c.XCoordinate, c.YCoordinate));
                EndReached = true;
            }

            SortAdjacentList(c.Adjacents);

            int numAdjacents = c.Adjacents.Count;

            // Select a random adjacent
            int rand = Rand.Next(numAdjacents);

            //Diagnostics.Logger.Instance.Log(String.Format("Random: {0}", rand));
            Cell cell = c.Adjacents[rand];

            //Diagnostics.Logger.Instance.Log(String.Format("Cell[{0}, {1}]", cell.XCoordinate, cell.YCoordinate));

            if (cell.XCoordinate >= this.Rows - 1 && cell.YCoordinate >= this.Columns - 1)
            {
                Diagnostics.Logger.Instance.Log("End of the maze reached.");
                cell.CellState = CELL_STATE.VISITED;
                EndReached = true;
            }

            while(!EndReached)//foreach (Cell cell in c.Adjacents)
            {
                if (cell.CellState == CELL_STATE.OPEN) // this cell is open
                {
                    c.CellState = CELL_STATE.VISITED;
                    FindEnd(cell);
                }
                else
                    return;

            }
        }

        public void FindEndRecursiveBacktracker(Cell c)
        {
            while (!EndReached)
            {
                if (c.XCoordinate >= this.Rows - 1 && c.YCoordinate >= this.Columns - 1)
                {
                    Diagnostics.Logger.Instance.Log("End of the maze reached.");
                    c.CellState = CELL_STATE.VISITED;
                    EndReached = true;
                }

                if (!c.HasAllAdjacentsBeenVisited())
                {
                    SortAdjacentList(c.Adjacents);
                    int numAdjacents = c.Adjacents.Count;

                    // Select a random adjacent
                    int rand = Rand.Next(numAdjacents);

                    //Diagnostics.Logger.Instance.Log(String.Format("Random: {0}", rand));
                    Cell cell = c.Adjacents[rand];

                    _stack.Push(cell);
                    cell.CellState = CELL_STATE.VISITED;
                }
                else if (_stack.Count > 0)
                {
                    Cell cell = _stack.Pop();
                }
                else
                {
                    SortAdjacentList(c.Adjacents);
                    int numAdjacents = c.Adjacents.Count;

                    // Select a random adjacent
                    int rand = Rand.Next(numAdjacents);

                    //Diagnostics.Logger.Instance.Log(String.Format("Random: {0}", rand));
                    Cell cell = c.Adjacents[rand];                    
                }

            }
        }

        private void SortAdjacentList(List<Cell> unsorted)
        {
            // TODO: Allow the user to specify the Sorting algorithm. (Strategy Design Pattern)

            // Selection sort
            for (int i = 0; i < unsorted.Count - 1; i++)
            {
                int smallest = unsorted[i].AdjacentValue;
                int pos = i;
                for (int j = i + 1; j < unsorted.Count; j++)
                    if (unsorted[j].AdjacentValue < smallest)
                    {
                        smallest = unsorted[j].AdjacentValue;
                        pos = j;
                    }
                Cell temp = unsorted[pos];
                unsorted[pos] = unsorted[i];
                unsorted[i] = temp;
            }
        }
    }
}