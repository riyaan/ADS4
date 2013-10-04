using System;
using System.Collections.Generic;

namespace Entities.Maze
{
    public class Common
    {
        public Random Rand { get; set; }
        public bool EndReached { get; set; }
        public Maze Maze { get; set; }

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

        public void CreateAdjacents(Maze maze)
        {
            // TODO: Add diagonal adjacents.
            // The adjacents are currently only:
            // towards the left, the top, right, and beneath

            Maze = maze;

            for (int i = 0; i < Maze.Rows; i++)
            {
                for (int j = 0; j < Maze.Columns; j++)
                {
                    if ((i - 1) >= 0)
                    {
                        Maze.Grid[i, j].Adjacents.Add(Maze.Grid[i - 1, j]);
                        Maze.Grid[i - 1, j].AdjacentValue = Maze.Rand.Next(Maze.Size);
                    }

                    if ((i + 1) < Maze.Rows)
                    {
                        Maze.Grid[i, j].Adjacents.Add(Maze.Grid[i + 1, j]);
                        Maze.Grid[i + 1, j].AdjacentValue = Maze.Rand.Next(Maze.Size);
                    }

                    if ((j - 1) >= 0)
                    {
                        Maze.Grid[i, j].Adjacents.Add(Maze.Grid[i, j - 1]);
                        Maze.Grid[i, j - 1].AdjacentValue = Maze.Rand.Next(Maze.Size);
                    }

                    if ((j + 1) < Maze.Columns)
                    {
                        Maze.Grid[i, j].Adjacents.Add(Maze.Grid[i, j + 1]);
                        Maze.Grid[i, j + 1].AdjacentValue = Maze.Rand.Next(Maze.Size);
                    }
                }
            }
        }
    }
}
