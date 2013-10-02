using System.Collections.Generic;

namespace Entities
{
    #region ENUMS

    public enum CELL_STATE { OPEN, VISITED }

    #endregion ENUMS

    public class Cell
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public List<Cell> Adjacents { get; set; }
        public CELL_STATE CellState { get; set; }
        public bool AllAdjacentsVisited { get; set; }
        public int AdjacentValue { get; set; }

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
