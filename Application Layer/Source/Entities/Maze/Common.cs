using System;
using System.Collections.Generic;

namespace Entities.Maze
{
    public class Common
    {
        public Random Rand;
        public bool EndReached;
        public Maze Maze;
        public Stack<Cell> Stack;

        public void SortAdjacentList(List<Cell> unsorted)
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

        /// <summary>
        /// Selects a random adjacent cell for this current cell.
        /// </summary>
        /// <param name="currentCell">The current cell.</param>
        /// <returns>A random neighbouring cell.</returns>
        public Cell SelectRandomAdjacent(Cell currentCell)
        {
            SortAdjacentList(currentCell.Adjacents);
            int numAdjacents = currentCell.Adjacents.Count;

            // Select a random adjacent
            int rand = Rand.Next(numAdjacents);

            currentCell = currentCell.Adjacents[rand];
            currentCell.CellState = CELL_STATE.VISITED;
            return currentCell;
        }
    }
}
