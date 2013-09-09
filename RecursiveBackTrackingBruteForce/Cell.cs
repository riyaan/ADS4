using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveBackTrackingBruteForce
{
    public enum CellState { OPEN, VISITED }

    public class Cell
    {
        public Cell(CellState cellState)
        {
            this.State = cellState;

            walls = new List<Wall>(4);
            walls.Add(new Wall(WallDirection.NORTH, WallState.UP));
            walls.Add(new Wall(WallDirection.SOUTH, WallState.UP));
            walls.Add(new Wall(WallDirection.WEST, WallState.UP));
            walls.Add(new Wall(WallDirection.EAST, WallState.UP));
        }

        private List<Wall> walls;

        public List<Wall> Walls
        {
            get { return walls; }
            set { walls = value; }
        }

        private int xCoordinate;

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }

        private int yCoordinate;

        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        private CellState state;

        internal CellState State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
