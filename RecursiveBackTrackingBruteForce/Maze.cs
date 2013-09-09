using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveBackTrackingBruteForce
{
    public class Maze
    {
        Hashtable direction;

        public Hashtable Direction
        {
          get { return direction; }
          set { direction = value; }
        }        

        int[,] grid;

        public int[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private List<Cell> cells;

        public List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        private Random rand;

        private Logger _logger;

        public Maze(int row, int column)
        {
            _logger = Logger.Instance;

            Grid = new int[row, column];
            rand = new Random((int)DateTime.Now.Ticks);

            Direction = new Hashtable();
            Direction.Add("N", 1);
            Direction.Add("S", 2);
            Direction.Add("W", 3);
            Direction.Add("E", 4);
        }

        public void InitializeMaze()
        {
            Cells = new List<Cell>(Grid.Length);

            for (int m = 0; m < Grid.Length; m++)
            {
                Cells.Add(new Cell(CellState.OPEN));
            }

            int c = 0;
            for (int i = 0; i < Grid.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
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

        public void CarvePassage()
        {            
            SelectRandomDirection(0, 0, false);
        }

        private void SelectRandomDirection(int startx, int starty, bool done)
        {
            if (done)
                return;

            int r = rand.Next(1, 5);
            //Console.WriteLine("Random 0-5: {0}", r);
            _logger.Log(String.Format("Random 0-5: {0}", r));

            int nextx = 0, nexty = 0;

            bool canMove = true;

            switch (r)
            {
                case 1: // N                   
                    if ((starty + 1) > GetGridRowMax())
                    {
                        _logger.Log("Cannot move North. Border has been reached.");
                        canMove = false;
                    }

                    if (HasCellBeenVisited(startx, starty + 1))
                    {
                        _logger.Log("Cannot move North. Cell has already been visited.");
                        canMove = false;
                    }

                    if(canMove)
                    {
                        _logger.Log("Moving North");
                        nextx = startx;
                        nexty = starty + 1;

                        // break down the wall of the previous cell
                        BreakDownWall(startx, starty, WallDirection.NORTH);

                        // break down the opposite wall of the new cell
                        UpdateCellState(nextx, nexty, WallDirection.SOUTH);
                    }
                    break;
                case 2: // S
                    if ((starty - 1) < 0)
                    {
                        canMove = false;
                        _logger.Log("Cannot move South. Border has been reached.");
                    }

                    if (HasCellBeenVisited(startx, starty - 1))
                    {
                        canMove = false;
                        _logger.Log("Cannot move South. Cell has already been visited.");
                    }
                    
                    if(canMove)                    
                    {
                        _logger.Log("Moving South");
                        nextx = startx;
                        nexty = starty - 1;

                        // break down the wall of the previous cell
                        BreakDownWall(startx, starty, WallDirection.SOUTH);

                        UpdateCellState(nextx, nexty, WallDirection.NORTH);
                    }
                    break;
                case 3: // W
                    if ((startx - 1) < 0)
                    {
                        _logger.Log("Cannot move West. Border has been reached.");
                        canMove = false;
                    }

                    if(HasCellBeenVisited(startx - 1, starty))
                    {
                        canMove = false;
                        _logger.Log("Cannot move West. Cell has already been visited.");
                    }                    

                    if(canMove)
                    {
                        _logger.Log("Moving West");
                        nextx = startx - 1;
                        nexty = starty;

                        // break down the wall of the previous cell
                        BreakDownWall(startx, starty, WallDirection.WEST);

                        UpdateCellState(nextx, nexty, WallDirection.EAST);
                    }
                    break;
                case 4: // E
                    if ((startx + 1) > GetGridRowMax())
                    {
                        _logger.Log("Cannot move East. Border has been reached.");
                        canMove = false;
                    }

                    if(HasCellBeenVisited(startx+1, starty))
                    {
                        _logger.Log("Cannot move East. Cell has already been visited.");
                        canMove = false;
                    }                    

                    if(canMove)
                    {
                        _logger.Log("Moving East");
                        nextx = startx + 1;
                        nexty = starty;

                        // break down the wall of the previous cell
                        BreakDownWall(startx, starty, WallDirection.EAST);

                        UpdateCellState(nextx, nexty, WallDirection.WEST);
                    }
                    break;
            }

            _logger.Log(String.Format("Start x: {0}___ Start y: {1}", startx, starty));
            _logger.Log(String.Format("Next x: {0}___ Next y: {1}", nextx, nexty));

            if (nextx == 0 && nexty == 0)
            {
                _logger.Log("Reached the beginning.");
                // done = true;
            }

            if (nextx >= GetGridRowMax() && nexty >= GetGridColumnMax())
            {
                _logger.Log("Reached the End.");
                done = true;
            }

            SelectRandomDirection(nextx, nexty, done);
        }

        private void BreakDownWall(int startx, int starty, WallDirection wallDirection)
        {
            foreach (Cell c in this.Cells)
            {
                if (c.XCoordinate.Equals(startx) && c.YCoordinate.Equals(starty))
                {
                    foreach (Wall w in c.Walls)
                    {
                        if (w.Direction == wallDirection)
                        {
                            w.State = WallState.DOWN;
                        }
                    }
                }
            }
        }

        private bool HasCellBeenVisited(int startx, int p)
        {
            bool found = false;

            foreach (Cell c in this.Cells)
            {
                if (c.XCoordinate.Equals(startx) && c.YCoordinate.Equals(p) && c.State == CellState.VISITED)
                {
                    found = true; return found;
                }
            }
            return found;
        }

        private void UpdateCellState(int xCoord, int yCoord, WallDirection wallDirection)
        {            
            foreach (Cell c in this.Cells)
            {
                if (c.XCoordinate.Equals(xCoord) && c.YCoordinate.Equals(yCoord))
                {
                    c.State = CellState.VISITED;
                    foreach (Wall w in c.Walls)
                    {
                        if (w.Direction == wallDirection)
                            w.State = WallState.DOWN;
                    }
                    break;
                }
            }
        }

        private int GetGridRowMax()
        {
            return Grid.GetLength(0);
        }

        private int GetGridColumnMax()
        {
            return Grid.GetLength(1);
        }
    }
}