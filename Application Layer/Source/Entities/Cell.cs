using System.Collections.Generic;

namespace Entities
{
    #region ENUMS

    public enum CELL_STATE { OPEN, VISITED }

    #endregion ENUMS

    public class Cell
    {
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

        List<Cell> adjacents;

        public List<Cell> Adjacents
        {
            get { return adjacents; }
            set { adjacents = value; }
        }

        private CELL_STATE cellState;

        public CELL_STATE CellState
        {
            get { return cellState; }
            set { cellState = value; }
        }

        private bool allAdjacentsVisited;

        public bool AllAdjacentsVisited
        {
            get { return allAdjacentsVisited; }
            set { allAdjacentsVisited = value; }
        }

        private int adjacentValue;

        public int AdjacentValue
        {
            get { return adjacentValue; }
            set { adjacentValue = value; }
        }

        public Cell()
        {            
        }

        public bool HasAllAdjacentsBeenVisited()
        {
            AllAdjacentsVisited = true;

            foreach (Cell c in this.Adjacents)
            {
                if (c.CellState == CELL_STATE.OPEN)
                {
                    AllAdjacentsVisited = false;
                    break;
                }
            }

            return AllAdjacentsVisited; 
        }
    }
}
