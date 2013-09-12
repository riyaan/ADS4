using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum COMMAND { L1, L2, R1, R2, F1, F2 }

    public class ArrowController
    {
        /**
        *  Singleton implementation 
        **/
        #region Singleton

        private static ArrowController instance = null;

        private ArrowController() { }

        public static ArrowController getInstance()
        {
            if (instance == null)
            {
                instance = new ArrowController();
            }

            return instance;
        }

        #endregion Singleton

        private List<CellContext> grid;

        public List<CellContext> Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private ArrowContext arrowContext;

        public ArrowContext ArrowContext
        {
            get { return arrowContext; }
            set { arrowContext = value; }
        }

        public void InitializeGrid()
        {
            List<CellContext> _grid = new List<CellContext>(9);
            for (int m = 0; m < 9; m++)
            {
                _grid.Add(new CellContext(new ConcreteStateOpen()));
            }

            int c = 0;
            for (int i = 0; i < _grid.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {                        
                        //Console.WriteLine(String.Format("I: {0}, J: {1}, K: {2}, C: {3}", i, j, k, c));
                        _grid[c].XCoordinate = j;
                        _grid[c].YCoordinate = k;
                        c++;

                        if (c >= _grid.Count)
                            break;
                    }
                    if (c >= _grid.Count)
                        break;
                }
                if (c >= _grid.Count)
                    break;
            }

            Grid = _grid;
        }

        public void InitializeArrow()
        {
            ArrowContext = new ArrowContext(new ConcreteStateNorth());
        }

        public void Command(COMMAND command)
        {
            switch (command)
            {
                case COMMAND.L1:
                    ArrowContext.CurrentState.MoveEast(ArrowContext);
                    break;
                case COMMAND.L2:
                    break;
                case COMMAND.R1:
                    ArrowContext.CurrentState.MoveWest(ArrowContext);
                    break;
                case COMMAND.R2:
                    break;
                case COMMAND.F1:
                    ArrowContext.CurrentState.MoveNorth(ArrowContext);
                    break;
                case COMMAND.F2:
                    break;                
            }
        }
    }
}
