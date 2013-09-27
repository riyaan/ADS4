using System;
using System.Collections.Generic;

namespace Entities.Maze
{
    /// <summary>
    /// Used this web page as a guide for these algorithms.
    /// http://en.wikipedia.org/wiki/Maze_generation_algorithm
    /// </summary>
    public abstract class MazeStrategy
    {        
        public abstract void CreateMaze(Cell cell);
    }

    /// <summary>
    /// This is a modified version of the randomized Prim Algorithm for generating a Maze.
    /// The maze is not always solvable though.
    /// </summary>
    public class PrimsAlgorithm : MazeStrategy
    {
        private Common _common;

        public PrimsAlgorithm(Maze maze)
        {
            _common = new Common();
            _common.Rand = new Random((int)DateTime.Now.Ticks);
            _common.EndReached = false;
            _common.Maze = maze;
        }

        public override void CreateMaze(Cell cell)
        {
            // if all adjacents has been visited quit
            if (cell.HasAllAdjacentsBeenVisited())
            {
                Diagnostics.Logger.Instance.Log("All adjacents for this cell has been visited. Can't go anywhere.");
                Diagnostics.Logger.Instance.Log(String.Format("End position: Cell[{0}, {1}]", cell.XCoordinate, cell.YCoordinate));
                _common.EndReached = true;
            }

            _common.SortAdjacentList(cell.Adjacents);
            int numAdjacents = cell.Adjacents.Count;

            // Select a random adjacent
            int rand = _common.Rand.Next(numAdjacents);
            Cell currentCell = cell.Adjacents[rand];

            if (cell.XCoordinate >= this._common.Maze.Rows - 1 && cell.YCoordinate >= this._common.Maze.Columns - 1)
            {
                Diagnostics.Logger.Instance.Log("End of the maze reached.");
                currentCell.CellState = CELL_STATE.VISITED;
                _common.EndReached = true;
            }

            while (!_common.EndReached)//foreach (Cell cell in c.Adjacents)
            {
                if (currentCell.CellState == CELL_STATE.OPEN) // this cell is open
                {
                    cell.CellState = CELL_STATE.VISITED;
                    CreateMaze(currentCell);
                }
                else
                    return;
            }
        }
    }
    
    /// <summary>
    /// This is a recursive backtracking method for creating a Maze.
    /// </summary>
    /// <param name="c">The starting cell.</param>
    public class RecursiveBacktrackingAlgorithm : MazeStrategy
    {
        private Common _common;

        public RecursiveBacktrackingAlgorithm(Maze maze)
        {
            _common = new Common();
            _common.Rand = new Random((int)DateTime.Now.Ticks);
            _common.EndReached = false;
            _common.Maze = maze;
            _common.Stack = new Stack<Cell>();
        }

        public override void CreateMaze(Cell cell)
        {
            Cell currentCell = cell;
            currentCell.CellState = CELL_STATE.VISITED;

            while (!_common.EndReached)
            {
                if (currentCell.XCoordinate >= this._common.Maze.Rows - 1 && currentCell.YCoordinate >= this._common.Maze.Columns - 1)
                {
                    Diagnostics.Logger.Instance.Log("End of the maze reached.");
                    currentCell.CellState = CELL_STATE.VISITED;
                    _common.EndReached = true;
                }

                if (!currentCell.HasAllAdjacentsBeenVisited())
                {
                    currentCell = _common.SelectRandomAdjacent(currentCell);
                    _common.Stack.Push(currentCell);
                }
                else if (_common.Stack.Count > 0)
                    currentCell = _common.Stack.Pop();
                else
                    currentCell = _common.SelectRandomAdjacent(currentCell);
            }
        }
    }
}
