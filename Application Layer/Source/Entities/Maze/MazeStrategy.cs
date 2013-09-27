using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Maze
{
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

    public class RecursiveBacktrackingAlgorithm : MazeStrategy
    {
        private Common _common;

        public RecursiveBacktrackingAlgorithm(Maze maze)
        {
            _common = new Common();
            _common.Rand = new Random((int)DateTime.Now.Ticks);
            _common.EndReached = false;
            _common.Maze = maze;
        }

        public override void CreateMaze(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
