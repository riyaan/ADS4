using Diagnostics;
using Entities;
using Entities.Maze;
using System.Configuration;

namespace Controllers
{
    // TODO: Make this a singleton as well? (Singleton Design Pattern)
    public class MazeController
    {
        const string PRIM = "prim";
        const string RECURSIVE_BACKTRACKING = "recursiveBacktracking";
        const string CUSTOM = "custom";

        const string SECTION = "appSettings";
        const string ALGORITHM_SECTION = "mazeAlgorithm";

        public int Rows { get; set; }
        public int Columns { get; set; }
        public Maze Maze { get; set; }

        private Common _common;

        public MazeController(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            CreateMaze(Rows, Columns);            
        }

        private void CreateMaze(int rows, int columns)
        {
            Maze = new Maze(rows, columns);

            _common = new Common();
            _common.CreateAdjacents(Maze);

            ConfigurationManager.RefreshSection(SECTION);
            string algorithm = ConfigurationManager.AppSettings[ALGORITHM_SECTION];
            
            if(algorithm.Equals(PRIM))
                Maze.SetMazeCreationStrategy(new PrimsAlgorithm(Maze));
            else if(algorithm.Equals(RECURSIVE_BACKTRACKING))
                Maze.SetMazeCreationStrategy(new RecursiveBacktrackingAlgorithm(Maze));
            else if (algorithm.Equals(CUSTOM))
                Maze.SetMazeCreationStrategy(new CustomAlgorithm(Maze));

            Maze.CreateMaze();

            PrintMaze();
        }

        /// <summary>
        /// TODO: Disable this method when debugging is complete.
        /// Prints a textual representation of the maze.
        /// This is for Debugging purposes.
        /// </summary>
        private void PrintMaze()
        {
            string output = System.Environment.NewLine;
            for (int i = Maze.Rows - 1; i >= 0; i--)
            {
                for (int j = Maze.Columns - 1; j >= 0; j--)
                {
                    if (Maze.Grid[i, j].CellState == CELL_STATE.OPEN)
                        output += "|O|";
                    else
                        output += "|X|";
                }
                output += System.Environment.NewLine;
            }

            Logger.Instance.Log(output);
        }
    }
}
