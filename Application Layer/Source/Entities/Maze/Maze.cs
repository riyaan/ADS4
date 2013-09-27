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

        private MazeStrategy _mazeStrategy;

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

        // TODO: Implement the Strategy Design Pattern
        // http://en.wikipedia.org/wiki/Maze_generation_algorithm
        /// <summary>
        /// This is a modified version of the randomized Prim Algorithm for generating a Maze.
        /// The maze is not always solvable though.
        /// </summary>
        /// <param name="c">The starting cell.</param>
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
            Cell cell = c.Adjacents[rand];            

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

        // TODO: Implement the Strategy Design Pattern
        // http://en.wikipedia.org/wiki/Maze_generation_algorithm
        /// <summary>
        /// This is a recursive backtracking method for creating a Maze.
        /// </summary>
        /// <param name="c">The starting cell.</param>
        public void FindEndRecursiveBacktracker(Cell c)
        {
            Cell currentCell = c;
            currentCell.CellState = CELL_STATE.VISITED;

            while (!EndReached)
            {
                if (currentCell.XCoordinate >= this.Rows - 1 && currentCell.YCoordinate >= this.Columns - 1)
                {
                    Diagnostics.Logger.Instance.Log("End of the maze reached.");
                    currentCell.CellState = CELL_STATE.VISITED;
                    EndReached = true;
                }

                if (!currentCell.HasAllAdjacentsBeenVisited())
                {
                    currentCell = SelectRandomAdjacent(currentCell);
                    _stack.Push(currentCell);
                }
                else if (_stack.Count > 0)
                    currentCell = _stack.Pop();
                else
                    currentCell = SelectRandomAdjacent(currentCell);
            }
        }

        /// <summary>
        /// Selects a random adjacent cell for this current cell.
        /// </summary>
        /// <param name="currentCell">The current cell.</param>
        /// <returns>A random neighbouring cell.</returns>
        private Cell SelectRandomAdjacent(Cell currentCell)
        {
            SortAdjacentList(currentCell.Adjacents);
            int numAdjacents = currentCell.Adjacents.Count;

            // Select a random adjacent
            int rand = Rand.Next(numAdjacents);

            currentCell = currentCell.Adjacents[rand];
            currentCell.CellState = CELL_STATE.VISITED;
            return currentCell;
        }

        private void SortAdjacentList(List<Cell> unsorted)
        {
            throw new NotImplementedException();
            //// TODO: Allow the user to specify the Sorting algorithm. (Strategy Design Pattern)

            //// Selection sort
            //for (int i = 0; i < unsorted.Count - 1; i++)
            //{
            //    int smallest = unsorted[i].AdjacentValue;
            //    int pos = i;
            //    for (int j = i + 1; j < unsorted.Count; j++)
            //        if (unsorted[j].AdjacentValue < smallest)
            //        {
            //            smallest = unsorted[j].AdjacentValue;
            //            pos = j;
            //        }
            //    Cell temp = unsorted[pos];
            //    unsorted[pos] = unsorted[i];
            //    unsorted[i] = temp;
            //}
        }
    }
}