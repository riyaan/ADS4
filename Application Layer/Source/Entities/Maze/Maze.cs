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

        private List<CellContext> cells;

        public List<CellContext> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;            
        }

        public void InitializeMaze()
        {
            int totalCells = (Rows * Columns);            
            Cells = new List<CellContext>(totalCells);

            for (int m = 0; m < totalCells; m++)
            {
                CellContext cellContext = new CellContext(new ConcreteStateOpen());
                Cells.Add(cellContext);
            }

            int c = 0;
            for(int i=0; i<totalCells; i++)
            {                
                for (int j = 0; j < Rows; j++)
                {
                    for (int k = 0; k < Columns; k++)
                    {
                        //Console.WriteLine(String.Format("I: {0}, J: {1}, K: {2}, C: {3}", i, j, k, c));
                        Cells[c].XCoordinate = j;
                        Cells[c].YCoordinate = k;
                        c++;

                        if (c >= Cells.Count)
                            break;
                    }
                    if (c >= Cells.Count)
                        break;
                }
                if (c >= Cells.Count)
                    break;
            }
        }
    }
}