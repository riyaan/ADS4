using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Maze
{
    public class Common
    {
        public Random Rand;
        public bool EndReached;
        public Maze Maze;

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
    }
}
